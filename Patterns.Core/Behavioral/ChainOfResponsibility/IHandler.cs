namespace Patterns.Core.Behavioral.ChainOfResponsibility;

public interface IHandler<T, TError>
{
    TError? Handle(Request<T> request);
}
