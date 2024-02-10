using System;
using Volo.Abp.Application.Dtos;

namespace AsapTask.Polygon.Dto
{

    public class PolygonDataDto : EntityDto<int>
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
