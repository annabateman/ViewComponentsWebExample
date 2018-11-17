using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace DataProvider
{
    public class StarWarsApi<T> {
        private string _baseUrl => "https://swapi.co/apis";

        public async Task<IList<T>> RetrieveItemList(string apiUrl) {
            HttpClient client = new HttpClient();
            try {
                HttpResponseMessage apiResponse = await client.GetAsync($"{_baseUrl}/{apiUrl}");

                if (apiResponse.IsSuccessStatusCode) {
                    return JsonConvert.DeserializeObject<StarWarsApiListResult<T>>(apiResponse.Content.ReadAsStringAsync().Result)?.Results;
                }
            }
            catch { }
            return GetResultsOverride();
        }

        public async Task<T> RetrieveItem(string apiUrl, int itemId) {
            HttpClient client = new HttpClient();
            try {
                HttpResponseMessage apiResponse = await client.GetAsync($"{_baseUrl}/{apiUrl}/{itemId}");

                if (apiResponse.IsSuccessStatusCode) {
                    T jsonResult = JsonConvert.DeserializeObject<T>(apiResponse.Content.ReadAsStringAsync().Result);
                    return jsonResult;
                }
            }
            catch { }

            return GetResultsOverride().FirstOrDefault(f => (int)f.GetType().GetProperty("Id").GetValue(f, null) == itemId);
        }

        private IList<T> GetResultsOverride() {
            string currentRunningPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string fileName = $"{currentRunningPath}\\{typeof(T).Name}.json";
            string fileContents = File.ReadAllText(fileName);

            return JsonConvert.DeserializeObject<StarWarsApiListResult<T>>(fileContents)?.Results;
        }
    }
}
