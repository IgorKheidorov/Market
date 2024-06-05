using JSON_Repository.DAL;

namespace JSON_Repository.Repositories;

internal class JSONProductDescriptionRepository : JSONRepository<ProductDescriptionEntity>
{
    protected override string RepositoryFileName { get; set; } = "ProductDescriptions.json";

}
