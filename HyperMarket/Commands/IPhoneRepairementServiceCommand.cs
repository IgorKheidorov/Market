using HyperMarket.Services;

namespace HyperMarket.Commands;

internal class IPhoneRepairementServiceCommand : Command
{
    IPhoneRepairementService _reciever;

    public IPhoneRepairementServiceCommand(IPhoneRepairementService service)
    {
        _reciever = service;
    }

    // Simulation of time consuming operation
    public override string Execute()
    {
        var operationResult = _reciever.RepairIPhone();
        Thread.Sleep(1000);
        return operationResult;
    }

    public override async Task<string> ExecuteAsync() =>
        await Task.Run(()=> Execute());

    

    public override bool Undo()
    {
        throw new NotImplementedException();
    }
}
