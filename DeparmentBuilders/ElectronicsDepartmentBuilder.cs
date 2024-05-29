using OOPSample.Entitys;
using OOPSample.Interfaces;
using OOPSample.Repositories;

namespace OOPSample.DeparmentBuilders;

internal class ElectronicsDepartmentBuilder: DepartmentBuilder
{
    public override string Name { get; protected set; } = "Electonics";
    
    public ElectronicsDepartmentBuilder(JSONRepository<Product> repository) : base(repository) { }

    public override List<SellerConsultant> BuildConsultants()
    {
        List<SellerConsultant> list = new();
        // the correct consulants have to be checked here!!!!!!!!!!!
        list.Add(new SellerConsultant("John", "TV"));
        list.Add(new SellerConsultant("Smith", "PC"));
        list.Add(new SellerConsultant("Mike", "PhoneMaster"));
        return list;
    }

    public override List<string> BuildEquipment()
    {
        List<string> list = new();
        // the correct consulants have to be checked here!!!!!!!!!!!
        list.Add("power supply");
        
        return list;
    }

    public override WareHouse BuildWareHouse()
    {
        /// flexiblibity (to change code with minimum risk) == add new abstarction level
        WareHouse house = new();
        _repository.GetAll().ToList().ForEach(x => house.AddProduct(x));
        return house;
    }
}
