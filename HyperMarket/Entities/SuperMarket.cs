using OOPSample.DeparmentBuilders;
using OOPSample.Interfaces;
using OOPSample.Services;

namespace OOPSample.Entities;

internal class SuperMarket
{
    //1. Departments (food, cloths, building materials, electronics, etc...
    public string Name { get; private set; }
    private List<StoreDepartment> _departments = new();
    private ServiceProvider _serviceProvider;

    private static object _locker = new object();

    public static int Number = 0;
    public static string NumbersString = "";

    public static void ChangeNumber()
    {
        Thread.Sleep(500);

         lock (_locker)
        {
            NumbersString += Number.ToString();
            Number++; Number--;
        }
    }


    private List<ICommand> _preOrders = new();

    public SuperMarket(string name)
    {
        Name = name;
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
        _departments.Add(DepartmentBuilderFactory.GetInstance().GetBuilder("Food").Build());
        _departments.Add(DepartmentBuilderFactory.GetInstance().GetBuilder("Electonics").Build());
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

}
