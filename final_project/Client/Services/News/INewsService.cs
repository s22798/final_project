using final_project.Shared.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace final_project.Client.Services.News
{
    public interface INewsService
    {
        Task<IEnumerable<NewsDTO>> GetNewsByTicker(string ticker);
    }
}
