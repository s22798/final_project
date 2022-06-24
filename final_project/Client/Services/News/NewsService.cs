using final_project.Shared.Models.DTOs;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace final_project.Client.Services.News
{
    public class NewsService : INewsService
    {
        private string apiKey = "WNux2CEcikhLeVRxJ0m4_K5tvBvvmBVF";
        public async Task<IEnumerable<NewsDTO>> GetNewsByTicker(string ticker)
        {
            IEnumerable<NewsDTO> news = null;
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync($"https://api.polygon.io/v2/reference/news?ticker={ticker}&limit=5&apiKey={apiKey}");
                var jObject = JObject.Parse(json);

                news = jObject.SelectToken("results").ToObject<IEnumerable<NewsDTO>>();
            }
            return news;
        }

        
    }
}
