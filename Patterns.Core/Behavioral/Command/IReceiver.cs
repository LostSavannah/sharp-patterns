namespace Patterns.Core.Behavioral.Command;

public interface IReceiver
{
    void Receive(ICommand command); 
}
