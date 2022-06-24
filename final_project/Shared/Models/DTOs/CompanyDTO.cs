using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project.Shared.Models.DTOs
{
    public class CompanyDTO
    {
        public string Ticker { get; set; }
        public string Name { get; set; }
        public string Locale { get; set; }
        public string Sic_description { get; set; }
        public BrandingDTO Branding { get; set; }
        public string? Logo_url { get; set; }
    }
}
