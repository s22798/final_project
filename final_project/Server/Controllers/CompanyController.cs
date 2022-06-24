using final_project.Server.Data;
using final_project.Server.Models;
using final_project.Server.Services.CompanyService;
using final_project.Shared.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace final_project.Server.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            return Ok(await _companyService.GetCompanies());
        }

        [HttpGet("tickerid/{ticker}")]
        public async Task<IActionResult> GetCompanyIdByTicker(string ticker)
        {
            if (await _companyService.IfCompanyExists(ticker)) return Ok(await _companyService.GetCompanyIdByTicker(ticker));

            return NotFound();
        }

        [HttpPost("watchlist")]
        public async Task<IActionResult> AddToWatchlist([FromBody]CompanyUser companyUser)
        {
            if (await _companyService.IfAlreadyInWatchlist(companyUser.IdCompany, companyUser.IdUser)) return BadRequest("Already in watchlist");
            await _companyService.AddToCompanyUser(companyUser.IdCompany, companyUser.IdUser);
            return Ok("Added to watchlist");
        }

        [HttpGet("watchlist/{idUser}")]
        public async Task<IActionResult> GetWatchlistForUser(string idUser)
        {
            return Ok(await _companyService.GetCompaniesForUser(idUser));
        }

        [HttpDelete("watchlist")]
        public async Task<IActionResult> DeleteFromWatchlist([FromBody]CompanyUser companyUser)
        {
            await _companyService.DeleteFromWatchlist(companyUser.IdCompany, companyUser.IdUser);
            return Ok("Deleted from watchlist");

        }

        [HttpGet("{ticker}")]
        public async Task<IActionResult> GetCompanyByTicker(string ticker)
        {
            if (await _companyService.IfCompanyExists(ticker)) return Ok(await _companyService.GetCompanyByTicker(ticker));

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddCompany([FromBody]CompanyDTO company)
        {
            if(!await _companyService.IfCompanyExists(company.Ticker))
            {
                await _companyService.AddCompany(company);
                return Ok(company);
            }

            return BadRequest();
        }
    }
}
