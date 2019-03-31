using System.Collections.Generic;
using bi.domain.data;
using bi.domain.model.bi_event;
using core.domain.data;
using Npgsql;
using System.Linq;
using core.domain.extensions;

namespace bi.data.pg
{
  public class PgBiEventRepository : PgRepository<BiEventRoot>, IBiEventRepository
  {
    public PgBiEventRepository(DbContext context) : base(context)
    {
    }

    public override string Create(BiEventRoot item)
    {
      using (NpgsqlConnection conn = new NpgsqlConnection(
        this._context.ConnectionString))
      {
        conn.Open();

        Dictionary<string, dynamic> payload = item.Payload;
        foreach (KeyValuePair<string, dynamic> record in payload.Skip(1))
        {
          bool tableExists = this.TableExists(conn, record.Key);
          if(!tableExists)
          {
            CreateTable(conn, record.Key, record.Value);
          }

          bool mustReplace = this.IfExistsMustReplace(record.Value);
          if (mustReplace)
          {
            RemoveRecord(conn, record.Key, record.Value);
          }

          SaveRecord(conn, record.Key, record.Value);
        }

        KeyValuePair<string, dynamic> fact = payload.First();
        return SaveRecord(conn, fact.Key, fact.Value);
      }
    }

    private void CreateTable(NpgsqlConnection conn, string name,
      IDictionary<string, object> values)
    {
      using (NpgsqlCommand cmd = new NpgsqlCommand())
      {
        cmd.Connection = conn;
        cmd.CommandText = $@"CREATE TABLE bi.{name} (
id int4 PRIMARY KEY,
{this.GetColumnDefinitions(values)}
);";
        cmd.ExecuteNonQuery();
      }
    }

    private string GetColumnDefinitions(IDictionary<string, object> values)
    {
      string[] columns = this.GetColumnNames(values);
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
      if (values.ContainsKey("_replace"))
      {
        return values["_replace"].ToBool();
      }

      return false;
    }

    private void RemoveRecord(NpgsqlConnection conn, string name,
      IDictionary<string, object> values)
    {
      string id = values["id"].ToString();
      if (id.IsNows())
      {
        return;
      }

      using (NpgsqlCommand cmd = new NpgsqlCommand())
      {
        cmd.Connection = conn;
        cmd.CommandText = $"DELETE FROM {name} WHERE ID = '@id';";
        cmd.Parameters.AddWithValue("id", id);
        cmd.ExecuteNonQuery();
      }
    }

    private string SaveRecord(NpgsqlConnection conn, string name,
          IDictionary<string, object> values)
    {
      using (NpgsqlCommand cmd = new NpgsqlCommand())
      {
        cmd.Connection = conn;

        string[] columnNames = this.GetColumnNames(values);
        cmd.CommandText = $"INSERT INTO {name} " +
          $"('{string.Join("','", columnNames)}') " +
          $"VALUES(@{string.Join(",@", columnNames)}) " +
          $"ON CONFLICT DO NOTHING RETURNING ID;";

        foreach (string columnName in columnNames)
        {
          cmd.Parameters.AddWithValue(columnName, values[columnName]);
        }

        object res = cmd.ExecuteScalar();

        return res?.ToString();
      }
    }

    private bool TableExists(NpgsqlConnection conn, string name)
    {
      using (NpgsqlCommand cmd = new NpgsqlCommand())
      {
        cmd.Connection = conn;
        cmd.CommandText = @"SELECT EXISTS (
SELECT 1
FROM   information_schema.tables 
WHERE  table_schema = 'bi'
AND    table_name = '@name'
);";
        cmd.Parameters.AddWithValue(nameof(name), name);
        return cmd.ExecuteScalar().ToBool();
      }
    }
  }
}
