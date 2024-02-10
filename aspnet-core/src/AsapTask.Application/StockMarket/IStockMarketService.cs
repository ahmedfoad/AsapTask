using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace AsapTask.StockMarket
{
    public interface IStockMarketService : IApplicationService
    {
        Task FetchMarketStockData();
    }
}
