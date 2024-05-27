using OOPSample.Entitys;
using OOPSample.Interfaces;

namespace OOPSample.Repositories;

internal class JSONFoodRepository : JSONRepository<Product>
{
    protected override string RepositoryFileName { get; set; } = "Food.json";
  
}
