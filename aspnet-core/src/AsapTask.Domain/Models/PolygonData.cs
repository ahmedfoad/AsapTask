using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace AsapTask.Models
{
    public class PolygonData : Entity<int>
    {
        public string Status { get; set; }
        public DateTime From { get; set; }
        public string Symbol { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public decimal Volume { get; set; }
        public decimal AfterHours { get; set; }
        public decimal PreMarket { get; set; }
    }
}
