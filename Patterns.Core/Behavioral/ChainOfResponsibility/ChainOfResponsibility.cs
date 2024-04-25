namespace Patterns.Core.Behavioral.ChainOfResponsibility;

public class ChainOfResponsibility<T, TError> : IHandler<T, TError>
{
    List<IHandler<T, TError?>> handlers = new();

    public ChainOfResponsibility<T, TError> Handler(Func<Request<T>, TError?> handler) => 
        Handler(new GenericHandler<T, TError?>(handler));
    
    public ChainOfResponsibility<T, TError> Handler(IHandler<T, TError?> handler)
    {
        handlers.Add(handler);
        return this;
    }

    public TError? Handle(Request<T> request)
    {
        TError? error = default;
        foreach (var handler in handlers)
        {
            if ((error = handler.Handle(request)) != null) break;
        }
        return error;
    }

    public static ChainOfResponsibility<T, TError> Create(params Func<Request<T>, TError?>[] handlers)
    {
        ChainOfResponsibility<T, TError> result = new();
        handlers.ToList().ForEach(handler => {
            result.Handler(handler);
        });
        return result;
    }
}
