using HyperMarket.Commands;
using HyperMarket.Interfaces;

namespace HyperMarket.Services;

internal class IPhoneRepairementService : ServiceProvider
{
    public IPhoneRepairementService(IService service) : base(service) { }

    public override ICommand ProcessRequest(object item, string procedureDescription)
    {
        // analyze request
        bool analyzeResult = procedureDescription.Contains("IPhone"); // Is this my duty or not

        // process request
        return analyzeResult is true ? new IPhoneRepairementServiceCommand(this): _nextService?.ProcessRequest(item, procedureDescription);
    }

    public string RepairIPhone() => "IPhone is repaired";

}
