using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockPricesRepository.Interface
{
    public class Stock
    {
        [JsonProperty("open")]
        public double OpeningPrice { get; set; }
        [JsonProperty("close")]
        public double ClosingPrice { get; set; }
        public double ChangeInPrice { get; set; }
        public DateTime StockDate { get; set; }
    }
}
