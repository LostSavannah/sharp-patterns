using Patterns.Core.Behavioral.ChainOfResponsibility;
using Patterns.Tests.TestTools;

namespace Patterns.Tests.Behavioral.Tests;

[TestFixture]
public class ChainOfResponsibilityTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Handle_When_Not_Error_Visites_All()
    {
        int initial = 10;
        var holder = new Subject() { 
            IntProperty = initial
        };
        var chor = new ChainOfResponsibility<Subject, string>();
        chor.Handler(r =>
        {
            r.Value.IntProperty += 1;
            return null!;
        });
        chor.Handler(r =>
        {
            r.Value.IntProperty += 1;
            return null!;
        });
        string? result = chor.Handle(new(holder));
        Assert.That(holder.IntProperty, Is.EqualTo(initial+2));
        Assert.That(result, Is.Null);
    }

    [Test]
    public void Handle_When_Error_Returns_Error()
    {
        string failure = "Error";
        var chor = new ChainOfResponsibility<Subject, string>();
        chor.Handler(r => failure);
        string? result = chor.Handle(new(new Subject()));
        Assert.That(result, Is.EqualTo(failure));
    }
}
