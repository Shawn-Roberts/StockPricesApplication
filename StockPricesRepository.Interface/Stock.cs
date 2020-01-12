using System;
using System.Collections.Generic;
using System.Text;

namespace StockPricesRepository.Interface
{
    public class Stock
    {
        public string StockName { get; set; }
        public string StockTicker { get; set; }
        public double OpeningPrice { get; set; }
        public double ClosingPrice { get; set; }
        public double ChangeInPrice { get; set; }
        public DateTime StockDate { get; set; }
    }
}
