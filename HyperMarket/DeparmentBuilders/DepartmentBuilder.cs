using HyperMarket.Entities;
using HyperMarket.Interfaces;
using SuperMarketEntities.Entities;
using SuperMarketEntities.Interfaces;

namespace HyperMarket.DeparmentBuilders;

internal abstract class DepartmentBuilder : IDepartmentBuilder
{
    public abstract string Name { get; protected set; }
    
    protected IUnitOfWork  _unitOfWork;

    protected DepartmentBuilder(IUnitOfWork unitOfWork) =>
        _unitOfWork = unitOfWork is not null ? unitOfWork : throw new ArgumentNullException();

    public abstract List<Employee> BuildConsultants();
    public abstract List<string> BuildEquipment();
    public abstract WareHouse BuildWareHouse();

    public StoreDepartment Build() => new StoreDepartment(Name, BuildConsultants(), BuildEquipment(), BuildWareHouse());
}
