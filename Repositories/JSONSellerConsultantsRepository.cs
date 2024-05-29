using OOPSample.Entitys;
using OOPSample.Repositories;

namespace HyperMarket.Repositories;

internal class JSONSellerConsultantsRepository: JSONRepository<SellerConsultant>
{
    protected override string RepositoryFileName { get; set; } = "SellerConsultants.json";
}
