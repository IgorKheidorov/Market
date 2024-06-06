using JSON_Repository.DAL;

namespace JSON_Repository.Repositories;

internal class JSONProductRepository : JSONRepository<ProductEntity>
{
    public JSONProductRepository(string name, string path) : base(name, path){}

    protected override string RepositoryFileName { get; set; } = "Products.json";
    
}
