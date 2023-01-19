using Newtonsoft.Json;

namespace InscalePracticalFirst.Domain.Services
{
    public static class HttpUtils<T>
    {
        public static async Task<T> GetAsync(string uri, HttpClient httpClient)
        {
            var apiResult = await httpClient.GetAsync(uri);
            if (apiResult.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<T>(await apiResult.Content.ReadAsStringAsync());

            throw new Exception("Get operation failed");
        }
    }
}
