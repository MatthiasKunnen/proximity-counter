using System.Collections.Generic;
using System.Net.Http;
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

        public static string Post(string url, params KeyValuePair<string, string>[] payload)
        {
            using (var httpClient = new HttpClient())
            {
                var content = new FormUrlEncodedContent(payload);
                var response = httpClient.PostAsync(url, content).Result;
                var responseString = response.Content.ReadAsStringAsync().Result;
                return responseString;
            }
        }

        public static T Post<T>(string url, params KeyValuePair<string, string>[] payload)
        {
            var responseJson = Post(url, payload);
            return JsonConvert.DeserializeObject<T>(responseJson);
        }
    }
}
