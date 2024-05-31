using HyperMarket.DAL;

namespace OOPSample.Repositories;

internal class JSONProductDescriptionRepository : JSONRepository<ProductDescriptionEntity>
{
    protected override string RepositoryFileName { get; set; } = "ProductDescriptions.json";

}
