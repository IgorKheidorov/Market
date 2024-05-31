
using OOPSample.Entities;

namespace HyperMarket.Interfaces;

internal interface IUnitOfWork
{
    IEnumerable<Product> GetProducts();
    IEnumerable<SellerConsultant> GetFoodDepartmentSellerConsultants();
    IEnumerable<SellerConsultant> GetElectronicsDepartmentSellerConsultants();
    bool SaveProducts(IEnumerable<Product> products);
    bool SaveConsultants(IEnumerable<SellerConsultant> consultants);
}
