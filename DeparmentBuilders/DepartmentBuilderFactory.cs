using OOPSample.Interfaces;
using OOPSample.Repositories;

namespace OOPSample.DeparmentBuilders;

internal class DepartmentBuilderFactory
{
    // Singleton
    #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private static DepartmentBuilderFactory _factory;
    private JSONFoodRepository _foodRepo;
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
        _builders.Add(new FoodDeparmentBuilder(new JSONFoodRepository()));
        _builders.Add(new ElectronicsDepartmentBuilder(new JSONElectronicsRepository()));
    }

    public IDepartmentBuilder GetBuilder(string name) => _builders.FirstOrDefault(x => (x as DepartmentBuilder)?.Name == name) ?? throw new ArgumentException(); 

}
