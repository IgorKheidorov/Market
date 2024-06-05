using HyperMarket.Commands;
using HyperMarket.Interfaces;

namespace HyperMarket.Services;

internal class BarberService : ServiceProvider
{
    // Schedule
    public BarberService(IService service) : base(service) { }

    public override ICommand ProcessRequest(object item, string procedureDescription)
    {
        // analyze request
        bool analyzeResult = procedureDescription.Contains("Barber"); // Is this my duty or not

        // process request
        return analyzeResult is true ? new BarberServiceCommand(this, new DateTime (2024, 5, 17, 9, 30, 0)) : _nextService?.ProcessRequest(item, procedureDescription);
    }

    public string CutHear() => "Cut is Done";

    public string ProposeWhiskey() => "Whyskey is drinked";
}
