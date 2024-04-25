using Patterns.Core.Behavioral.Memento;
using Patterns.Core.Behavioral.Observer;
using Patterns.Tests.TestTools;

namespace Patterns.Tests.Behavioral.Tests;

[TestFixture]
public class ObserverTests
{
    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void Publish_When_No_Subscriber_Does_Nothing()
    {
        var subject = new Subject() { IntProperty = 0 };
        var publisher = new Publisher<Subject>();
        var subscriber = new GenericSubscriber<Subject>(s => {
            subject.IntProperty += s.IntProperty;
        });
        publisher.Publish(new() { IntProperty = 8 });
        Assert.That(subject.IntProperty, Is.EqualTo(0));
    }

    [Test]
    public void Publish_When_Has_Subscribers_Notifies_All_Subscribers()
    {
        var subject = new Subject() { IntProperty = 0 };
        var publisher = new Publisher<Subject>();
        List<ISubscriber<Subject>> subscribers = new List<ISubscriber<Subject>>
        {
            new GenericSubscriber<Subject>(s => {
                subject.IntProperty += s.IntProperty;
            }),
            new GenericSubscriber<Subject>(s => {
                subject.IntProperty += s.IntProperty;
            })
        };
        List<ISubscription> subscriptions = subscribers.Select(publisher.Subscribe).ToList();
        publisher.Publish(new() { IntProperty = 8 });
        Assert.That(subject.IntProperty, Is.EqualTo(16));
    }

    [Test]
    public void Publish_When_Cancelled_Subscription_Does_Nothing()
    {
        var subject = new Subject() { IntProperty = 0 };
        var publisher = new Publisher<Subject>();
        List<ISubscriber<Subject>> subscribers = new List<ISubscriber<Subject>>
        {
            new GenericSubscriber<Subject>(s => {
                subject.IntProperty += s.IntProperty;
            }),
            new GenericSubscriber<Subject>(s => {
                subject.IntProperty += s.IntProperty;
            })
        };
        List<ISubscription> subscriptions = subscribers.Select(publisher.Subscribe).ToList();
        publisher.Publish(new() { IntProperty = 8 });
        Assert.That(subject.IntProperty, Is.EqualTo(16));
        subscriptions.ForEach(s => s.Cancel());
        publisher.Publish(new() { IntProperty = 8 });
        Assert.That(subject.IntProperty, Is.EqualTo(16));
    }

}
