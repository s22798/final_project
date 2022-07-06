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
        private readonly ICompanyDbService _companyService;
        public CompanyController(ICompanyDbService companyService)
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
