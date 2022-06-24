using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<CompanyUser> CompanyUsers { get; set; }
    }
}
