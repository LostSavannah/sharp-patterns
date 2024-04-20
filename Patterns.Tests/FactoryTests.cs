using Patterns.Core.Creational.Factory;
using Patterns.Tests.TestTools;

namespace Patterns.Tests;

[TestFixture]
public class FactoryTests
{
    Random random = new Random();
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Create_When_Factory_Creates_Then_Instance_Gets_Created()
    {
        IFactory<Subject> factory = new Factory<Subject>();
        ISubject subject = factory.Create();
        Assert.That(subject, Is.Not.Null);
    }

    [Test]
    [Repeat(6)]
    public void Create_When_Parametrized_Factory_Creates_Then_Instance_Gets_Created_With_Parameter()
    {
        IFactory<Subject, int> factory = new Factory<Subject, int>();
        int parameter = random.Next(100);
        Subject subject = factory.Create(parameter);
        Assert.That(subject.IntProperty, Is.EqualTo(parameter));
    }

    [Test]
    [Repeat(6)]
    public void Create_When_Parametrized_Factory_Creates_Without_Parameter_Then_Instance_Gets_Created_With_Default_Value()
    {
        int parameter = random.Next(100);
        Subject subject = new Factory<Subject, int>(parameter).Create();
        Assert.That(subject.IntProperty, Is.EqualTo(parameter));
    }

    [Test]
    public void Create_When_Non_Parametrized_Factory_Creates_Without_Parameter_Then_Instance_Gets_Created_With_Default_Type_Value()
    {
        Subject subject = new Factory<Subject, int>().Create();
        Assert.That(subject.IntProperty, Is.EqualTo(0));
    }
}