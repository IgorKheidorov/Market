
using OOPSample.Entitys;

namespace HyperMarket.Interfaces;

internal interface IUnitOfWork
{
    List<Product> GetFoodProducts();
    List<Product> GetElectronicProducts();
    List<SellerConsultant> GetFoodDepartmentSellerConsultants();
    List<SellerConsultant> GetElectronicsDepartmentSellerConsultants();
}
