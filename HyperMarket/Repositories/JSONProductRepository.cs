using HyperMarket.DAL;

namespace OOPSample.Repositories;

internal class JSONProductRepository : JSONRepository<ProductEntity>
{
    protected override string RepositoryFileName { get; set; } = "Products.json";
    
}
