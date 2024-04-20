using Patterns.Core.Creational.Singleton;
using Patterns.Tests.TestTools;

namespace Patterns.Tests;

[TestFixture]
public class SingletonTests
{
    Random random = new Random();
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Singleton_Then_Throws_Nothing()
    {
        Assert.That(() => Singleton<Subject>.Instance, Throws.Nothing);
    }

    [Test]
    public void Singleton_When_Multiple_Then_Instance_Is_Shared()
    {
        int value = random.Next(0, 100);
        Subject subject1 = Singleton<Subject>.Instance;
        Subject subject2 = Singleton<Subject>.Instance;
        subject1.IntProperty = value;
        Assert.That(subject2.IntProperty, Is.EqualTo(value));
    }
}