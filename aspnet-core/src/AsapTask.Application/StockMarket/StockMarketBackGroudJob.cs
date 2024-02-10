using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.BackgroundWorkers.Quartz;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Threading;

namespace AsapTask.StockMarket
{
    public class StockMarketBackGroudJob : QuartzBackgroundWorkerBase, ISingletonDependency
    {
        private readonly IStockMarketService _stockMarketService;
        //IStockMarketService stockMarketService
        public StockMarketBackGroudJob(IStockMarketService stockMarketService)
        {
            JobDetail = JobBuilder.Create<StockMarketBackGroudJob>().WithIdentity(nameof(StockMarketBackGroudJob)).Build();
            Trigger = TriggerBuilder.Create()
               .WithIdentity(nameof(StockMarketBackGroudJob))
               .StartNow()
               .WithSimpleSchedule(x => x
                   .WithIntervalInHours(6) // Run every 6 hours
                   .RepeatForever())
               .Build();
            _stockMarketService = stockMarketService;
        }

        public override Task Execute(IJobExecutionContext context)
        {
            try
            {
                Logger.LogInformation("Executed MyLogWorker..!");
                _stockMarketService.FetchMarketStockData();
                Logger.LogInformation("Done ..");

            }
            catch (Exception ex)
            {

                Logger.LogError(ex.Message);
            }
            return Task.CompletedTask;
        }
    }


}
