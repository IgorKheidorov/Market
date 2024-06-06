using HyperMarket.Entities;
using SuperMarketEntities.Entities;

namespace HyperMarket.Interfaces;

internal interface IDepartmentBuilder
{
    List<Employee> BuildConsultants();
    List<string> BuildEquipment();
    WareHouse BuildWareHouse();

    StoreDepartment Build();
}
