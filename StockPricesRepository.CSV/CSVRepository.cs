using System;
using System.Collections.Generic;
using System.Configuration;

using StockPricesRepository.Interface;
using System.IO;

namespace StockPricesRepository.CSV
{
    public class CSVRepository : IStockPricesRepository
    {
        //FIELDS
        private readonly string path;
        //CONSTRUCTORS
        public CSVRepository()
        {
            var fileName = ConfigurationManager.AppSettings["CSVFileName"];
            path = AppDomain.CurrentDomain.BaseDirectory + fileName;
        }
        //METHODS
        public IEnumerable<Stock> GetStockPrice()
        {
            var stocks = new List<Stock>();

            if (File.Exists(path))
            {
                    StreamReader reader = new StreamReader(path);
                    string line;
                    while((line = reader.ReadLine()) != null)
                    {
                        var elements = line.Split(",");
                        var stock = new Stock()
                        {
                            StockName = elements[0],
                            StockTicker = elements[1],
                            OpeningPrice = Double.Parse(elements[2]),
                            ClosingPrice = Double.Parse(elements[3]),
                            ChangeInPrice = Math.Abs(Double.Parse(elements[3]) - Double.Parse(elements[2])),
                            StockDate = DateTime.Parse(elements[4])
                        };
                        stocks.Add(stock);
                        
                    }
            }
            return stocks;
        }
    }
}
