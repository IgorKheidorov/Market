using HyperMarket.DeparmentBuilders;
using HyperMarket.Interfaces;
using HyperMarket.Services;
using SuperMarketEntities.Entities;
using SuperMarketEntities.Interfaces;

namespace HyperMarket.Entities;

internal class HyperMarketItem: IDisposable
{
    //1. Departments (food, cloths, building materials, electronics, etc...
    public string Name { get; private set; }
    private List<StoreDepartment> _departments = new();
    private ServiceProvider _serviceProvider;
    private IUnitOfWork _dataSource;

    private List<ICommand> _preOrders = new();
    
    public HyperMarketItem(string name, IUnitOfWork dataSource)
    {
        Name = name;
        _dataSource = dataSource;
        CreateServices();
        PrepareForOpen();
    }

    private void CreateServices()
    {
        _serviceProvider = new BarberService(
            new IPhoneRepairementService(
            new AgeCheckService( // filter for next processing
            new AlcoService(
            new SmokeService(null)))));
    }

    private void PrepareForOpen()
    {
        _departments.Add(InfrastructureBuilderFactory.GetInstance(_dataSource).GetBuilder("Food").Build());
        _departments.Add(InfrastructureBuilderFactory.GetInstance(_dataSource).GetBuilder("Electonics").Build());
    }

    public void AddProduct(Product product)
    {
        var list = _dataSource.GetProducts(x => true).ToList();
        list.Add(product);
        _dataSource.SaveProducts(list);
    }

    public void ServeClient(object item, string requestDescription)
    {
        ICommand result = _serviceProvider.ProcessRequest(item, requestDescription);
    }

    public void SetPreOrder(object item, string requestDescription)
    {
        _preOrders.Add(_serviceProvider.ProcessRequest(item, requestDescription));
    }


    // invoker
    public IEnumerable<string> DoPreorders()
    {
        // thread-safety       
        List<Task<string>> tasks = new();
        _preOrders[0].ExecuteAsync();

        return tasks.Select(x => x.Result).ToList();
    }

    public void Dispose()
    {
        _dataSource?.Dispose();
    }
}
