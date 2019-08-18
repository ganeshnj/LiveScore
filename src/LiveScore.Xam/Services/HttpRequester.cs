using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using LiveScore.Xam.Helpers;
using Newtonsoft.Json;

namespace LiveScore.Xam.Services
{
    public class HttpRequester : HttpClient, IHttpRequester
    {
        public HttpRequester(HttpMessageHandler handler) : base(handler)
        {
        }

        public async Task<IEnumerable<T>> GetItemsAsync<T>(string url)
        {
            var uri = new Uri($"https://{Settings.ApiServer}/{url}");
            var response = await GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var Items = JsonConvert.DeserializeObject<List<T>>(content);
                return Items;
            }
            throw new Exception(response.ReasonPhrase);
        }

        public async Task<T> GetItemAsync<T>(string url)
        {
            var uri = new Uri($"{Settings.ApiServer}/{url}");
            var response = await GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var Item = JsonConvert.DeserializeObject<T>(content);
                return Item;
            }
            throw new Exception(response.ReasonPhrase);
        }
    }
}
