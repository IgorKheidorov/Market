
using OOPSample.Entitys;

namespace OOPSample.Interfaces;

internal interface IDepartmentBuilder
{
    List<SellerConsultant> BuildConsultants();
    List<string> BuildEquipment();
    WareHouse BuildWareHouse();

    StoreDepartment Build();
}
