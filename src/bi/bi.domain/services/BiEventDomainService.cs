using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace bi.domain.services
{
  public sealed class BiEventDomainService
  {
    internal IDictionary<string, IDictionary<string, object>> ParsePayload(
      string name, string payload)
    {
      // TODO: validate name against the catalog of valid facts

      Dictionary<string, object> root =
        JsonConvert.DeserializeObject<Dictionary<string, object>>(
          payload,
          new JsonSerializerSettings()
          {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
          });

      IDictionary<string, object> fact = new Dictionary<string, object>();

      IDictionary<string, IDictionary<string, object>> res 
        = new Dictionary<string, IDictionary<string, object>>
      {
        { "f_" + name, fact }
      };

      foreach (string key in root.Keys)
      {
        if(root[key] is JObject)
        {
          res.Add("dim_" + key, this.GetDimensionValues((JObject)root[key]));
        }
        else
        {
          fact.Add(key, root[key]);
        }
      }

      return res;
    }

    private IDictionary<string, object> GetDimensionValues(JObject values)
    {
      IDictionary<string, object> res = new Dictionary<string, object>();

      foreach (KeyValuePair<string, JToken> item in values)
      {
        res.Add(item.Key, item.Value.ToObject<object>());
      }

      return res;
    }
  }
}
