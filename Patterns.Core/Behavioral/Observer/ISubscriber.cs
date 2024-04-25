namespace Patterns.Core.Behavioral.Observer;

public interface ISubscriber<T>
{
    void Notify(T notification);
}
