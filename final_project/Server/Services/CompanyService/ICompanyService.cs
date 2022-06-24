using final_project.Server.Models;
using final_project.Shared.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace final_project.Server.Services.CompanyService
{
    public interface ICompanyService
    {
        Task<bool> IfCompanyExists(string ticker);
        Task<Company> GetCompanyByTicker(string ticker);
        Task<IEnumerable<Company>> GetCompanies();
        Task AddCompany(CompanyDTO company);
        Task<int> GetCompanyIdByTicker(string ticker);
        Task AddToCompanyUser(int idCompany, string idUser);
        Task<IEnumerable<Company>> GetCompaniesForUser(string idUser);
        Task<bool> IfAlreadyInWatchlist(int idCompany, string idUser);
        Task DeleteFromWatchlist(int idCompany, string idUser);
    }
}
