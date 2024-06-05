using HyperMarket.Interfaces;

namespace HyperMarket.Services;

internal class AgeCheckService: ServiceProvider
{
    public AgeCheckService(IService service) : base(service) { }

    public override ICommand ProcessRequest(object item, string procedureDescription)
    {
        throw new NotImplementedException();        
    }

}
