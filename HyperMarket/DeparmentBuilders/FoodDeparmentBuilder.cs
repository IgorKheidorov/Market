using HyperMarket.Interfaces;
using OOPSample.Entities;
using OOPSample.Interfaces;
using OOPSample.Repositories;

namespace OOPSample.DeparmentBuilders;

internal class FoodDeparmentBuilder : DepartmentBuilder
{
    public override string Name { get; protected set; } = "Food";

    public FoodDeparmentBuilder(IUnitOfWork work) : base(work) { }

    public override WareHouse BuildWareHouse()
    {
        /// flexiblibity (to change code with minimum risk) == add new abstarction level
        WareHouse house = new();
        _unitOfWork.GetProducts(x => x.Category == "Food").ToList().ForEach(x => house.AddProduct(x));
        return house;
    }

    public override List<SellerConsultant> BuildConsultants() =>
        _unitOfWork.GetFoodDepartmentSellerConsultants().ToList();

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
