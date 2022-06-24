using final_project.Shared.Models.DTOs;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace final_project.Client.Services.Company
{
    public interface ICompanyService
    {
        Task<CompanyDTO> GetCompanyByTicker(string ticker);
        Task<IEnumerable<CompanySearchDTO>> GetSearchedCompany(string text);
        Task AddCompanyToDb(string ticker);
        Task<CompanyDTODB> GetCompanyFromDb(string ticker);
        Task<IEnumerable<CompanyDTODB>> GetCompaniesFromDb();
        Task<HttpResponseMessage> AddToCompanyUsers(string idUser, int idCompany);
        Task<IEnumerable<CompanyDTODB>> GetWatchlist(string idUser);
        Task DeleteFromCompanyUsers(string idUser, int idCompany);
    }
}
