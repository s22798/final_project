using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project.Shared.Models.DTOs
{
    public class CompanyDTODB
    {
        public string Ticker { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Description { get; set; }
        public string Logo_url { get; set; }
    }
}
