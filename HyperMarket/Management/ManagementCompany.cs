using HyperMarket.Entities;
using HyperMarket.Interfaces;

namespace HyperMarket.Management
{
    internal class ManagementCompany
    {
        private const string SMALL_MARKET_PATH = "D:\\Data";
        //private const string connectionString = 
        
        public HyperMarketItem CreateHyperMarket(string name, string type) 
        {
            IHyperMarketCreator creator = type switch
            {
                "Small" => new SmallHyperMarketCreator(name, SMALL_MARKET_PATH),
                "Big" => new BigHyperMarketCreator(name),
                _ => throw new ArgumentException()
            };

            creator.CreateEmployees();
            creator.CreateProducts();
            return new HyperMarketItem(name, creator.GetDataSource());
        }
    }
}
