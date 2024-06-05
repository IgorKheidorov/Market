using SuperMarketEntities.Entities;

namespace JSON_Repository.Repositories;

internal class JSONSellerConsultantsRepository: JSONRepository<SellerConsultant>
{
    protected override string RepositoryFileName { get; set; } = "SellerConsultants.json";
}
