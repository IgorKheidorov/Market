using SuperMarketEntities.Entities;

namespace HyperMarket.Entities;

internal class StoreDepartment 
{
    public string Name { get; }

    public List<Employee> Consultants { get; private set; }
    public List<string> Equipment { get; private set; }
    public WareHouse WareHouse { get; private set; }

    public StoreDepartment(string name, List<Employee> consultants, List<string> equipment, WareHouse warhouse)
    {
        Name = name;
        Consultants = consultants;
        Equipment = equipment;
        WareHouse = warhouse;
    }
}
