
using Patterns.Core.Behavioral.Command;
using Patterns.Tests.TestTools;

namespace Patterns.Tests.Behavioral.Tests;

[TestFixture]
public class CommandTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Execute_When_Initialized_Uses_Initial_Command()
    {
        var stateSubject = new Subject
        {
            IntProperty = 1
        };
        var receiver = new GenericReceiver(e => e.Execute());
        var invoker = new Invoker(receiver, new GenericCommand<Subject>(new() { IntProperty = 2 }, e => {
            stateSubject.IntProperty *= e.IntProperty;
        }));
        invoker.Execute();
        Assert.That(stateSubject.IntProperty, Is.EqualTo(2));
    }

    [Test]
    public void Execute_When_Changed_Uses_Changed_Command()
    {
        var stateSubject = new Subject
        {
            IntProperty = 1
        };
        var receiver = new GenericReceiver(e => e.Execute());
        var invoker = new Invoker(receiver, new GenericCommand<Subject>(new() { IntProperty = 2 }, e => {
            stateSubject.IntProperty *= e.IntProperty;
        }));
        invoker.Command = new GenericCommand<Subject>(new() { IntProperty = 3 }, e => {
            stateSubject.IntProperty = 4;
        });
        invoker.Execute();
        Assert.That(stateSubject.IntProperty, Is.EqualTo(4));
    }

    [Test]
    public void Execute_When_Sequential_Commands_Gets_Executed()
    {
        var stateSubject = new Subject
        {
            IntProperty = 1
        };
        var receiver = new GenericReceiver(e => e.Execute());
        var invoker = new Invoker(receiver, new GenericCommand<Subject>(new() { IntProperty = 2 }, e => {
            stateSubject.IntProperty *= e.IntProperty;
        }));
        invoker.Execute();
        invoker.Command = new GenericCommand<Subject>(new() { IntProperty = 3 }, e => {
            stateSubject.IntProperty *= e.IntProperty;
        });
        invoker.Execute();
        Assert.That(stateSubject.IntProperty, Is.EqualTo(6));
    }
}
