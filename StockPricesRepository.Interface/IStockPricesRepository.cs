using System;
using System.Collections.Generic;
using System.Text;

namespace StockPricesRepository.Interface
{
    public interface IStockPricesRepository 
    {
        IEnumerable<Stock> GetStockPrice();
    }
}
