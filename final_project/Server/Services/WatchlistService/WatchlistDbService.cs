using final_project.Server.Data;
using final_project.Server.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace final_project.Server.Services.WatchlistService
{
    public class WatchlistDbService : IWatchlistDbService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public WatchlistDbService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task AddToCompanyUser(int idCompany, string idUser)
        {
            var companyUser = new CompanyUser()
            {
                IdCompany = idCompany,
                IdUser = idUser
            };

            _applicationDbContext.Add(companyUser);

            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteFromWatchlist(int idCompany, string idUser)
        {
            var companyUser = new CompanyUser()
            {
                IdCompany = idCompany,
                IdUser = idUser
            };

            _applicationDbContext.Attach(companyUser);
            _applicationDbContext.Remove(companyUser);

            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Company>> GetCompaniesForUser(string idUser)
        {
            return await _applicationDbContext.CompanyUsers.Where(e => e.IdUser.Equals(idUser)).Select(e => e.Company).ToListAsync();
        }

        public async Task<bool> IfAlreadyInWatchlist(int idCompany, string idUser)
        {
            return await _applicationDbContext.CompanyUsers.Where(e => e.IdCompany == idCompany && e.IdUser.Equals(idUser)).AnyAsync();
        }
    }
}
