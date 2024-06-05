using HyperMarket.Entities;
using SuperMarketEntities.Entities;

namespace HyperMarket.Interfaces;

internal interface IDepartmentBuilder
{
    List<SellerConsultant> BuildConsultants();
    List<string> BuildEquipment();
    WareHouse BuildWareHouse();

    StoreDepartment Build();
}
