﻿namespace OOPSample.Entitys;

internal class StoreDepartment : Entity
{
    public string Name { get; }

    private List<SellerConsultant> _consultunts;
    private List<string> _equipment;
    private WareHouse _wareHouse;

    public StoreDepartment(string name, List<SellerConsultant> consultants, List<string> equipment, WareHouse warhouse)
    {
        Name = name;
        _consultunts = consultants;
        _equipment = equipment;
        _wareHouse = warhouse;
    }
}
