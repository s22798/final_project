using final_project.Server.Data;
using final_project.Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using final_project.Shared.Models.DTOs;

namespace final_project.Server.Services.CompanyService
{
    public class CompanyService : ICompanyService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CompanyService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task AddCompany(CompanyDTO company)
        {
            var comp = new Company()
            {
                Ticker = company.Ticker,
                Name = company.Name,
                Country = company.Locale,
                Description = company.Sic_description,
                Logo_url = company.Branding.Logo_url
            };

            _applicationDbContext.Add(comp);

            await _applicationDbContext.SaveChangesAsync();
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

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            return await _applicationDbContext.Companies.ToListAsync();
        }

        public async Task<IEnumerable<Company>> GetCompaniesForUser(string idUser)
        {
            return await _applicationDbContext.CompanyUsers.Where(e => e.IdUser.Equals(idUser)).Select(e => e.Company).ToListAsync();
        }

        public async Task<Company> GetCompanyByTicker(string ticker)
        {
            return await _applicationDbContext.Companies.FirstOrDefaultAsync(e => e.Ticker.Equals(ticker));
        }

        public async Task<int> GetCompanyIdByTicker(string ticker)
        {
            var comp = await _applicationDbContext.Companies.FirstOrDefaultAsync(e => e.Ticker.Equals(ticker));
            return comp.IdCompany;
        }

        public async Task<bool> IfAlreadyInWatchlist(int idCompany, string idUser)
        {
            return await _applicationDbContext.CompanyUsers.Where(e => e.IdCompany==idCompany && e.IdUser.Equals(idUser)).AnyAsync();
        }

        public async Task<bool> IfCompanyExists(string ticker)
        {
            return await _applicationDbContext.Companies.Where(e => e.Ticker.Equals(ticker)).AnyAsync();
        }
    }
}
