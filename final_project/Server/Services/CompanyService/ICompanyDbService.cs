using final_project.Server.Models;
using final_project.Shared.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace final_project.Server.Services.CompanyService
{
    public interface ICompanyDbService
    {
        Task<bool> IfCompanyExists(string ticker);
        Task<Company> GetCompanyByTicker(string ticker);
        Task<IEnumerable<Company>> GetCompanies();
        Task AddCompany(CompanyDTO company);
        Task<int> GetCompanyIdByTicker(string ticker);
    }
}
