using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ProximityCounter
{
    public static class JsonConveyor
    {
        public static JsonSerializerSettings JsonSerializerSettings { get; } = new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        public static async Task<string> Post(string url, params KeyValuePair<string, string>[] payload)
        {
            using (var httpClient = new HttpClient())
            {
                var content = new FormUrlEncodedContent(payload);
                var response = await httpClient.PostAsync(url, content);
                var responseString = await response.Content.ReadAsStringAsync();
                return responseString;
            }
        }

        public static async Task<T> Post<T>(string url, params KeyValuePair<string, string>[] payload)
        {
            var responseJson = await Post(url, payload);
            return JsonConvert.DeserializeObject<T>(responseJson);
        }
    }
}
