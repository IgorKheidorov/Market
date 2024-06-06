﻿using HyperMarket.Entities;
using SuperMarketEntities.Entities;
using SuperMarketEntities.Interfaces;

namespace HyperMarket.DeparmentBuilders;

internal class FoodDeparmentBuilder : DepartmentBuilder
{
    public override string Name { get; protected set; } = "Food";

    internal FoodDeparmentBuilder(IUnitOfWork work) : base(work) { }

    public override WareHouse BuildWareHouse()
    {
        /// flexiblibity (to change code with minimum risk) == add new abstarction level
        WareHouse house = new();
        _unitOfWork.GetProducts(x => x.Category == "Food").ToList().ForEach(x => house.AddProduct(x));
        return house;
    }

    public override List<Employee> BuildConsultants() =>
        _unitOfWork.GetPersonal().ToList();

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
