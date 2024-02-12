using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace StockMarketService.Model
{
    [DataContract]
    public class PolygonDataDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public DateTime From { get; set; }
        [DataMember]
        public string Symbol { get; set; }
        [DataMember]
        public decimal Open { get; set; }
        [DataMember]
        public decimal High { get; set; }
        [DataMember]
        public decimal Low { get; set; }
        [DataMember]
        public decimal Close { get; set; }
        [DataMember]
        public decimal Volume { get; set; }
        [DataMember]
        public decimal AfterHours { get; set; }
        [DataMember]
        public decimal PreMarket { get; set; }

    }
}