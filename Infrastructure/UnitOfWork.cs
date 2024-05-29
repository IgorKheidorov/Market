using HyperMarket.Interfaces;
using OOPSample.Entitys;

namespace HyperMarket.Infrastructure;

internal class UnitOfWork : IUnitOfWork
{
    List<Product> IUnitOfWork.GetElectronicProducts()
    {
        throw new NotImplementedException();
    }

    List<SellerConsultant> IUnitOfWork.GetElectronicsDepartmentSellerConsultants()
    {
        throw new NotImplementedException();
    }

    List<SellerConsultant> IUnitOfWork.GetFoodDepartmentSellerConsultants()
    {
        throw new NotImplementedException();
    }

    List<Product> IUnitOfWork.GetFoodProducts()
    {
        throw new NotImplementedException();
    }
}
