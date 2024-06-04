
using HyperMarket.Entityies;
using OOPSample.Entities;

namespace HyperMarket.Common;

public static class EnitytiesInitializer
{
    public static IEnumerable<Product> GetProducts()
    {
        List<Product> products = new();

        ProductDescription milkDescription1 = new()
        {
            Details = new() {
              {"Еat content", "1.5%" },
              {"Producer", "Milk company" },
              {"Expirity date", "05-11-2024" },              
            }
        };

        ProductDescription milkDescription2 = new()
        {
            Details = new() {
              {"Еat content", "3.5%" },
              {"Producer", "Milk company" },
              {"Expirity date", "05-11-2024" },
            }
        };

        ProductDescription tvPanasonicDescription = new()
        {
            Details = new() {
              {"Model", "TX-65LX650E 65\" LED 4K Android TV Dolby Vision Dolby Atmos HDMI 2.1" },
              {"Producer", "Panasonic" },
              {"Guarantee period", "5 years"},
            }
        };

        ProductDescription iPhoneDescription = new()
        {
            Details = new() {
              {"Model", "14" },
              {"Producer", "Apple" },
              {"Guarantee period", "2 years"},
            }
        };

        for (int i = 0; i < 5; i++)
        {
            products.Add(new Product("Milk", "Food", 0.9f, milkDescription1));
            products.Add(new Product("Milk", "Food", 1.5f, milkDescription2));
            products.Add(new Product("TV", "Electronics", 1000f, tvPanasonicDescription));
            products.Add(new Product("Modile phone", "Electronics", 2000f, iPhoneDescription));
        }

        return products;
    }
}
