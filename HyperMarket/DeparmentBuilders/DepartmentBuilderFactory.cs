using HyperMarket.Infrastructure;
using HyperMarket.Interfaces;
using OOPSample.Interfaces;
using System.Configuration;

namespace OOPSample.DeparmentBuilders;

internal class DepartmentBuilderFactory
{
    // Singleton
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private static DepartmentBuilderFactory _factory;
    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    private List<IDepartmentBuilder> _builders = new ();

    public static DepartmentBuilderFactory GetInstance() 
    {
        if (_factory is null)
        {
            _factory = new DepartmentBuilderFactory();            
        }

        return _factory;
    }

    private DepartmentBuilderFactory()
    {
        string source = ConfigurationManager.AppSettings["UnitOfWorkSource"] ?? "";
        IUnitOfWork unitOfWork = source == "JSON" ? new UnitOfWork() : throw new ArgumentNullException();
        
        _builders.Add(new FoodDeparmentBuilder(unitOfWork));
        _builders.Add(new ElectronicsDepartmentBuilder(unitOfWork));
    }

    public IDepartmentBuilder GetBuilder(string name) => _builders.FirstOrDefault(x => (x as DepartmentBuilder)?.Name == name) ?? throw new ArgumentException(); 

}
