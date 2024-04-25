namespace Patterns.Core.Behavioral.Observer;

public class Publisher<T>: IPublisher<T>
{
    List<ISubscriber<T>> subscribers = new(); 
    
    public void Publish(T value)
    {
        subscribers.ForEach(s => s.Notify(value));
    }

    public bool IsSubscribed(ISubscriber<T> subscriber) => subscribers.Contains(subscriber);

    public ISubscription Subscribe(ISubscriber<T> subscriber)
    {
        if (!IsSubscribed(subscriber)) subscribers.Add(subscriber);
        return new Subscription(this, subscriber);
    }
    public ISubscription Subscribe(Action<T> onNotify) => Subscribe(new GenericSubscriber<T>(onNotify));
    class Subscription : ISubscription, IDisposable
    {
        private readonly Publisher<T> publisher;
        private readonly ISubscriber<T> subscriber;

        public Subscription(Publisher<T> publisher, ISubscriber<T> subscriber)
        {
            this.publisher = publisher;
            this.subscriber = subscriber;
        }
        public void Cancel()
        {
            if (publisher.IsSubscribed(subscriber)) publisher.subscribers.Remove(subscriber);
        }

        public void Dispose() => Cancel();
    }

}

