using Patterns.Core.Behavioral.Memento;
using Patterns.Tests.TestTools;

namespace Patterns.Tests.Behavioral.Tests;

[TestFixture]
public class MementoTests
{
    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void Undo_When_Empty_Does_Nothing()
    {
        var subject = new Subject() { IntProperty = 0 };
        var caretaker = new Caretaker<Subject>();
        caretaker.Undo(subject);
        Assert.That(subject.IntProperty, Is.EqualTo(0));
    }

    [Test]
    public void Undo_When_Not_Empty_Undoes_Action_And_Uses_Memento()
    {
        string mementoName = "Test";
        var subject = new Subject() { IntProperty = 0 };
        var caretaker = new Caretaker<Subject>();
        caretaker.Add(subject.CreateSnapshot(mementoName));
        Assert.That(caretaker.Mementos.Any(m => m.name == mementoName), Is.True);
        subject.IntProperty = 20;
        Assert.That(subject.IntProperty, Is.EqualTo(20));
        caretaker.Undo(subject);
        Assert.That(caretaker.Mementos, Is.Empty);
        Assert.That(subject.IntProperty, Is.EqualTo(0));
    }

}
