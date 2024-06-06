using HyperMarket.Interfaces;
using SuperMarketEntities.Interfaces;
using JSON_Repository.Infrastructure;

namespace HyperMarket.DeparmentBuilders;

internal class InfrastructureBuilderFactory
{
    // Singleton
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private static InfrastructureBuilderFactory _factory;

    #pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    private List<IDepartmentBuilder> _builders = new ();

    public static InfrastructureBuilderFactory GetInstance(IUnitOfWork unitOfWork) 
    {
        if (_factory is null)
        {
            _factory = new InfrastructureBuilderFactory(unitOfWork);            
        }

        return _factory;
    }

    private InfrastructureBuilderFactory(IUnitOfWork unitOfWork)
    {   
        _builders.Add(new FoodDeparmentBuilder(unitOfWork));
        _builders.Add(new ElectronicsDepartmentBuilder(unitOfWork));
    }

    public IDepartmentBuilder GetBuilder(string name) => _builders.FirstOrDefault(x => (x as DepartmentBuilder)?.Name == name) ?? throw new ArgumentException(); 

}
