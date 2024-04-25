namespace Patterns.Core.Behavioral.Observer;

public interface IPublisher<T>
{
    bool IsSubscribed(ISubscriber<T> subscriber);
    ISubscription Subscribe(ISubscriber<T> subscriber);
    ISubscription Subscribe(Action<T> onNotify);
}
