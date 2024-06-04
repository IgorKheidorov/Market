using OOPSample.Interfaces;

namespace OOPSample.Commands;

internal abstract class Command : ICommand
{
    public DateTime TimeToStart { get; protected set; } = DateTime.Now;
    public abstract string Execute();
    public abstract Task<string> ExecuteAsync();
    public abstract bool Undo();
}
