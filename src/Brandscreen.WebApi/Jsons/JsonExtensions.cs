using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Brandscreen.WebApi.Jsons
{
    public static class JsonExtensions
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Converters = new JsonConverter[] {new StringEnumConverter()},
            NullValueHandling = NullValueHandling.Include
        };

        public static string ToJson<T>(this T obj)
        {
            return JsonConvert.SerializeObject(obj, Settings);
        }
    }
}