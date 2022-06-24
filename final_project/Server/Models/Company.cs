using System.Collections.Generic;

namespace final_project.Server.Models
{
    public class Company
    {
        public int IdCompany { get; set; }
        public string Ticker { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string Logo_url { get; set; }
        public virtual ICollection<CompanyUser> CompanyUsers { get; set; }
    }
}
