namespace Patterns.Core.Behavioral.ChainOfResponsibility;

public class GenericHandler<T, TError>(Func<Request<T>, TError?> handler) : IHandler<T, TError>
{
    public TError? Handle(Request<T> request) => handler(request);
}
