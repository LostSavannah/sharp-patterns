namespace Patterns.Core.Behavioral.Observer;

public class GenericSubscriber<T>(Action<T> onNotify) : ISubscriber<T>
{
    public void Notify(T notification) => onNotify(notification);
}
