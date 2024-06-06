using JSON_Repository.DAL;

namespace JSON_Repository.Repositories;

internal class JSONProductDescriptionRepository : JSONRepository<ProductDescriptionEntity>
{
    public JSONProductDescriptionRepository(string name, string path) : base(name, path){}

    protected override string RepositoryFileName { get; set; } = "ProductDescriptions.json";

}
