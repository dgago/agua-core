using System.Collections.Generic;
using System.Linq;

using bi.domain.data;
using bi.domain.model.bi_event;

using core.domain.data;
using core.domain.extensions;

using Npgsql;

namespace bi.data.pg
{
  public class PgBiEventRepository : PgRepository<BiEventRoot>, IBiEventRepository
  {
    const string SCHEMA = "bi";

    public PgBiEventRepository(IDbContext context) : base(context)
    {
    }

    public override string Create(BiEventRoot item)
    {
      using(NpgsqlConnection conn = new NpgsqlConnection(
        this._context.ConnectionString))
      {
        conn.Open();

        IDictionary<string, IDictionary<string, object>> payload = item.Payload;
        foreach(KeyValuePair<string, IDictionary<string, object>> record in payload.Skip(1))
        {
          this.EnsureTableAndSaveRecord(conn, record.Key, record.Value);
        }

        KeyValuePair<string, IDictionary<string, object>> fact = payload.First();
        return this.EnsureTableAndSaveRecord(conn, fact.Key, fact.Value);
      }
    }

    private void CreateTable(NpgsqlConnection conn, string name,
      IDictionary<string, object> values)
    {
      using (NpgsqlCommand cmd = new NpgsqlCommand())
      {
        cmd.Connection = conn;
        cmd.CommandText = $@"CREATE TABLE {SCHEMA}.{name} (id int4 PRIMARY KEY,
{this.GetColumnDefinitions(values)}
);";
        cmd.ExecuteNonQuery();
      }
    }

    private string EnsureTableAndSaveRecord(NpgsqlConnection conn, string tableName, IDictionary<string, object> values)
    {
      bool tableExists = this.TableExists(conn, tableName);
      if (!tableExists)
      {
        this.CreateTable(conn, tableName, values);
      }

      bool mustReplace = this.IfExistsMustReplace(values);
      if (mustReplace)
      {
        this.RemoveRecord(conn, tableName, values);
      }

      return this.SaveRecord(conn, tableName, values);
    }
    private string GetColumnDefinitions(IDictionary<string, object> values)
    {
      string[] columns = this.GetColumnNames(values).Where(x => x != "id").ToArray();
      const string type = " varchar(200) NULL";
      return string.Join($"{type},", columns) + type;
    }

    private string[] GetColumnNames(IDictionary<string, object> values)
    {
      List<string> res = new List<string>();

      res.AddRange(
        values.Select(x => x.Key).Where(x => !x.StartsWith("_"))
        );

      return res.ToArray();
    }

    private bool IfExistsMustReplace(IDictionary<string, object> values)
    {
      if(values.ContainsKey("_replace"))
      {
        return values["_replace"].ToBool();
      }

      return false;
    }

    private void RemoveRecord(NpgsqlConnection conn, string name,
      IDictionary<string, object> values)
    {
      string id = values["id"].ToString();
      if(id.IsNows())
      {
        return;
      }

      using(NpgsqlCommand cmd = new NpgsqlCommand())
      {
        cmd.Connection = conn;
        cmd.CommandText = $"DELETE FROM {SCHEMA}.{name} WHERE ID = @id;";
        cmd.Parameters.AddWithValue("id", id.ToInt32());
        cmd.ExecuteNonQuery();
      }
    }
    private string SaveRecord(NpgsqlConnection conn, string name,
          IDictionary<string, object> values)
    {
      using(NpgsqlCommand cmd = new NpgsqlCommand())
      {
        cmd.Connection = conn;

        string[] columnNames = this.GetColumnNames(values);
        cmd.CommandText = $"INSERT INTO {SCHEMA}.{name} " +
          $"({string.Join(",", columnNames)}) " +
          $"VALUES(@{string.Join(",@", columnNames)}) " +
          $"ON CONFLICT DO NOTHING RETURNING ID;";

        foreach(string columnName in columnNames)
        {
          cmd.Parameters.AddWithValue(columnName, values[columnName]);
        }

        object res = cmd.ExecuteScalar();

        return res?.ToString();
      }
    }

    private bool TableExists(NpgsqlConnection conn, string name)
    {
      using(NpgsqlCommand cmd = new NpgsqlCommand())
      {
        cmd.Connection = conn;
        cmd.CommandText = $@"SELECT EXISTS (
SELECT 1
FROM   information_schema.tables
WHERE  table_schema = @schema
AND    table_name = @name
);";
        cmd.Parameters.AddWithValue(nameof(name), name);
        cmd.Parameters.AddWithValue("schema", SCHEMA);
        return cmd.ExecuteScalar().ToBool();
      }
    }
  }
}