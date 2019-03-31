using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace bi.domain.services
{
  internal sealed class BiEventDomainService
  {
    internal IDictionary<string, dynamic> ParsePayload(string name, string payload)
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

      IDictionary<string, dynamic> res = new Dictionary<string, dynamic>
      {
        { "fact", fact }
      };

      foreach (string key in root.Keys)
      {
        if (root[key].GetType().ToString() == "object" ) {
          res.Add(key, root[key]);
        }
        else
        {
          fact.Add(key, root[key]);
        }
      }

      return res;
    }
  }
}
