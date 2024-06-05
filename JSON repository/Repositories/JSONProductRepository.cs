using JSON_Repository.DAL;

namespace JSON_Repository.Repositories;

internal class JSONProductRepository : JSONRepository<ProductEntity>
{
    protected override string RepositoryFileName { get; set; } = "Products.json";
    
}
