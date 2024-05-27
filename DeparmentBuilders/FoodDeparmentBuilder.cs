using OOPSample.Entitys;
using OOPSample.Interfaces;

namespace OOPSample.DeparmentBuilders;

internal class FoodDeparmentBuilder : DepartmentBuilder
{
    public override string Name { get; protected set; } = "Food";

    public FoodDeparmentBuilder(IRepository<Product> repository) : base(repository) { }

    public override WareHouse BuildWareHouse()
    {
        /// flexiblibity (to change code with minimum risk) == add new abstarction level
        WareHouse house = new();
        _repository.GetAll().ToList().ForEach(x => house.AddProduct(x));
        return house;
    }

    public override List<SellerConsultant> BuildConsultants()
    {
        List<SellerConsultant> list = new();
        // the correct consulants have to be checked here!!!!!!!!!!!
        list.Add(new SellerConsultant("John", "Cooker"));
        list.Add(new SellerConsultant("Smith", "MeatMaster"));
        list.Add(new SellerConsultant("Mike", "MilkMaster"));
        return list;
    }

    public override List<string> BuildEquipment()
    {
        List<string> list = new();
        // the correct consulants have to be checked here!!!!!!!!!!!
        list.Add("refrigerator");
        list.Add("meatbox");
        list.Add("milk box");
        return list;
    }
}
