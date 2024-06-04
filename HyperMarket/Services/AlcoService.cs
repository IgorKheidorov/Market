using OOPSample.Interfaces;

namespace OOPSample.Services;

internal class AlcoService : ServiceProvider
{
    public AlcoService(IService service) : base(service) { }
   
    public override ICommand ProcessRequest(object item, string procedureDescription)
    {
        throw new NotImplementedException();
        
    }
}
