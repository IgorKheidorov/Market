using HyperMarket.Interfaces;
namespace HyperMarket.Services;

internal abstract class ServiceProvider : IService
{
    protected IService? _nextService;

    public ServiceProvider(IService? nextService) 
    {
        _nextService = nextService;
    }

    public abstract ICommand ProcessRequest(object item, string procedureDescription);
}
