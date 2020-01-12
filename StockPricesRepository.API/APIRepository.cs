using Newtonsoft.Json;
using ServiceStack;
using StockPricesRepository.Interface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace StockPricesRepository.API
{
    public class APIRepository : IStockPricesRepository
    {
        //FIELDS
        private readonly string baseURI = ConfigurationManager.AppSettings["APIUrl"];
        private readonly string StockUrlApiKey = ConfigurationManager.AppSettings["APIKey"];
        public string symbol = "LULU";

        //CONSTRUCTORS
        public APIRepository()
        {

        }

        //METHODS
        public IEnumerable<Stock> GetStockPrice()
        {
            var stocks = new List<Stock>();


            var dailyPrices = $"{baseURI}&symbol={symbol}&apikey={StockUrlApiKey}&datatype=csv".GetStringFromUrl();
            var dailyPricesArray = dailyPrices.Split(Environment.NewLine.ToCharArray());
            dailyPricesArray = dailyPricesArray.Where(x => !String.IsNullOrEmpty(x)).ToArray();
            
            
            for (var line = 1; line < dailyPricesArray.Length; line ++)
            {
                var elements = dailyPricesArray[line].Split(",");
                var stock = new Stock()
                {
                    OpeningPrice = Double.Parse(elements[1]),
                    ClosingPrice = Double.Parse(elements[4]),
                    ChangeInPrice = Math.Abs(Double.Parse(elements[4]) - Double.Parse(elements[1])),
                    StockDate = DateTime.Parse(elements[0])
                };
                stocks.Add(stock);

            }

            return stocks;

        }
    }
}
