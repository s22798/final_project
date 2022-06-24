using final_project.Shared.Models.DTOs;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace final_project.Client.Services.Charts
{
    public class ChartService : IChartService
    {
        private string apiKey = "WNux2CEcikhLeVRxJ0m4_K5tvBvvmBVF";
        public async Task<IEnumerable<ChartDataDTO>> GetChartDataByTicker(string ticker)
        {
            IEnumerable<ChartDataDTO> chartDataDTOs = null;
            var today = DateTime.Now.ToString("yyyy-MM-dd");
            var yearago = DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd");
            using (var httpClient = new HttpClient())
            {
                var json = await httpClient.GetStringAsync($"https://api.polygon.io/v2/aggs/ticker/{ticker}/range/1/day/{yearago}/{today}?adjusted=true&sort=asc&apiKey={apiKey}");
                var jObject = JObject.Parse(json);

                ChartDataDTO.CurrentDateTime = DateTime.Now.AddYears(-1);
                chartDataDTOs = jObject.SelectToken("results").ToObject<IEnumerable<ChartDataDTO>>();
            }
            return chartDataDTOs;
        }
    }
}
