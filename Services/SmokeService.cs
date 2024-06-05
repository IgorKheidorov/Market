using OOPSample.Interfaces;

namespace OOPSample.Services;

internal class SmokeService : ServiceProvider
{
    public SmokeService(IService? service) : base(service) { }

    public override ICommand ProcessRequest(object item, string procedureDescription)
    {
        throw new NotImplementedException();
        
    }
}
