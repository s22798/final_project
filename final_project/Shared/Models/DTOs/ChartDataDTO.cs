using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project.Shared.Models.DTOs
{
    public class ChartDataDTO
    {
        [JsonProperty("o")]
        public double Open { get; set; }
        [JsonProperty("l")]
        public double Low { get; set; }
        [JsonProperty("c")]
        public double Close { get; set; }
        [JsonProperty("h")]
        public double High { get; set; }
        [JsonProperty("v")]
        public double Volume { get; set; }
        public DateTime Date { get; set; }

        public static DateTime CurrentDateTime { get; set; }

        public ChartDataDTO()
        {
            Date = CurrentDateTime;
            CurrentDateTime = CurrentDateTime.AddDays(1);
        }
    }
}
