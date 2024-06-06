using SuperMarketEntities.Entities;

namespace JSON_Repository.Repositories;

internal class JSONEmployeeRepository: JSONRepository<Employee>
{
    public JSONEmployeeRepository(string name, string path) : base(name, path){}

    protected override string RepositoryFileName { get; set; } = "SellerConsultants.json";
}
