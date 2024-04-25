namespace Patterns.Core.Behavioral.Command;

public class GenericReceiver(Action<ICommand> onReceive) : IReceiver
{
    public void Receive(ICommand command) => onReceive(command);

    public static GenericReceiver Create(Action<ICommand> onReceive) => new(onReceive);
}
