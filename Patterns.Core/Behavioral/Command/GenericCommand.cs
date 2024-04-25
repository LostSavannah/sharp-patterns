namespace Patterns.Core.Behavioral.Command;

public class GenericCommand<T>(T data, Action<T> onExecute) : ICommand
{
    public T Data { get; } = data;

    public void Execute() => onExecute(Data);
}
