
namespace Patterns.Core.Behavioral.ChainOfResponsibility;

public class Request<T>(T value)
{
    public T Value { get; set; } = value;
}
