namespace Patterns.Core.Behavioral.Command;

public class Invoker(IReceiver receiver, ICommand initialCommand) : ICommand
{
    public ICommand Command { get; set; } = initialCommand;
    public void Execute()
    {
        receiver.Receive(Command);
    }
}
