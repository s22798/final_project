using final_project.Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace final_project.Server.Services.WatchlistService
{
    public interface IWatchlistDbService
    {
        Task AddToCompanyUser(int idCompany, string idUser);
        Task<IEnumerable<Company>> GetCompaniesForUser(string idUser);
        Task<bool> IfAlreadyInWatchlist(int idCompany, string idUser);
        Task DeleteFromWatchlist(int idCompany, string idUser);
    }
}
