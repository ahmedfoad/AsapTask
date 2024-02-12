using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        internal static ServiceHost hostService = null;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                hostService = new ServiceHost(typeof(StockMarketService.StockMarketService));
                StockMarketService.StockMarketService mgmtService = new StockMarketService.StockMarketService();
                hostService.Open();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected override void OnStop()
        {
            hostService.Close();
        }
    }
}
