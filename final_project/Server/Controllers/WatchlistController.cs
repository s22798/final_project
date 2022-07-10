using final_project.Server.Models;
using final_project.Server.Services.WatchlistService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace final_project.Server.Controllers
{
    [Route("api/watchlists")]
    [ApiController]
    public class WatchlistController : ControllerBase
    {
        private readonly IWatchlistDbService _watchlistDbService;

        public WatchlistController(IWatchlistDbService watchlistDbService)
        {
            _watchlistDbService = watchlistDbService;
        }

        [HttpPost]
        public async Task<IActionResult> AddToWatchlist([FromBody] CompanyUser companyUser)
        {
            if (await _watchlistDbService.IfAlreadyInWatchlist(companyUser.IdCompany, companyUser.IdUser)) return BadRequest("Already in watchlist");
            await _watchlistDbService.AddToCompanyUser(companyUser.IdCompany, companyUser.IdUser);
            return Ok("Added to watchlist");
        }
        [HttpGet("{idUser}")]
        public async Task<IActionResult> GetWatchlistForUser(string idUser)
        {
            return Ok(await _watchlistDbService.GetCompaniesForUser(idUser));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFromWatchlist(int idCompany, string idUser)
        {
            await _watchlistDbService.DeleteFromWatchlist(idCompany, idUser);
            return Ok("Deleted from watchlist");
        }
    }
}
