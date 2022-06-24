using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project.Shared.Models.DTOs
{
    public class CompanySearchDTO
    {
        [Required(ErrorMessage = "The Ticker field is required.")]
        public string Ticker { get; set; }
        public string Name { get; set; }
        public string Currency_name { get; set; }
    }
}
