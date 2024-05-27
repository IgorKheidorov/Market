using OOPSample.Entitys;

namespace OOPSample.Repositories;

internal class JSONElectronicsRepository : JSONRepository<Product>
{
    protected override string RepositoryFileName { get; set; } = "Electronics.json";
}
