using SuperMarketEntities.Entities;

namespace SuperMarketEntities.Interfaces;

public interface IUnitOfWork
{
    IEnumerable<Product> GetProducts(Func<Product, bool> filter);
    IEnumerable<SellerConsultant> GetFoodDepartmentSellerConsultants();
    IEnumerable<SellerConsultant> GetElectronicsDepartmentSellerConsultants();
    bool SaveProducts(IEnumerable<Product> products);
    bool SaveConsultants(IEnumerable<SellerConsultant> consultants);
}
