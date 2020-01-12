using StockPricesRepository.API;
using StockPricesRepository.CSV;
using StockPricesRepository.Interface;
using System;

namespace StockPricesRepository.Factory
{
    public static class RepositoryFactory
    {
        //FIELDS

        //CONSTRUCTORS

        //METHODS
        public static IStockPricesRepository GetRepository(string repositoryType)
        {
            IStockPricesRepository repository = null;

            switch (repositoryType)
            {
                case "API": repository = new APIRepository();
                    break;
                case "CSV": repository = new CSVRepository();
                    break;
                default:
                    throw new ArgumentException("Invalid Repository Type Requested");
            }
            return repository;
        }
    }
}
