﻿using HyperMarket.Interfaces;
using OOPSample.Entitys;


namespace OOPSample.DeparmentBuilders;

internal class ElectronicsDepartmentBuilder: DepartmentBuilder
{
    public override string Name { get; protected set; } = "Electonics";

    public ElectronicsDepartmentBuilder(IUnitOfWork work) : base(work) { }

    public override List<SellerConsultant> BuildConsultants() =>
        _unitOfWork.GetElectronicsDepartmentSellerConsultants();

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
        _unitOfWork.GetElectronicProducts().ForEach(x => house.AddProduct(x));
        return house;
    }
}
