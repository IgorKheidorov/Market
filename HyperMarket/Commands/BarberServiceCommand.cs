using HyperMarket.Services;

namespace HyperMarket.Commands;

internal class BarberServiceCommand: Command
{
    BarberService _reciever;
    string _whatToDo;

    public BarberServiceCommand(BarberService service, DateTime timeToStart, string whatToDo = "Cut") 
    {
        _whatToDo = whatToDo;
        TimeToStart = timeToStart;
        _reciever = service;
    }
    public override string Execute()
    {
        string operationResult = "Not processed";
        if (DateTime.Now >= TimeToStart)
        {
            operationResult = _whatToDo == "Cut" ? _reciever.CutHear() : _reciever.ProposeWhiskey();
        }

        Thread.Sleep(1000);
        
        return operationResult;
    }

    public override async Task<string> ExecuteAsync() =>
        await Task.Run(() => Execute());

    public override bool Undo()
    {
        throw new NotImplementedException();
    }

}
