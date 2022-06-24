using final_project.Shared.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace final_project.Client.Services.Charts
{
    public interface IChartService
    {
        Task<IEnumerable<ChartDataDTO>> GetChartDataByTicker(string ticker);
    }
}
