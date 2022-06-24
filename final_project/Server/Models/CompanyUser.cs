namespace final_project.Server.Models
{
    public class CompanyUser
    {
        public int IdCompany { get; set; }
        public string IdUser { get; set; }
        public virtual Company Company { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
