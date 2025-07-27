using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace FrontEndWebApp.services
{
    public class ApiClient(HttpClient HttpClient) 
    {
        private readonly HttpClient httpClient = HttpClient;
        public Task<T> GetFromJsonAsync<T>(string path)
        {
            return httpClient.GetFromJsonAsync<T>(path);
        }
        public async Task<T1> PostAsync<T1>(string path, T1 postModel)
        {
            var res = await httpClient.PostAsJsonAsync(path, postModel);
            if (res != null && res.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T1>(await res.Content.ReadAsStringAsync());
            }

            return default;
        }
        public async Task<T1> PutAsync<T1>(string path, T1 putModel)
        {
            var res = await httpClient.PutAsJsonAsync(path, putModel);
            if (res != null && res.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<T1>(await res.Content.ReadAsStringAsync());
            }

            return default;
        }
        public async Task DeleteAsync(string path)
        {
            await httpClient.DeleteAsync(path);
        }
    }

    
}