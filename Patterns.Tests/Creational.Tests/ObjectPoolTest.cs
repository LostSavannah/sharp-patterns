using Patterns.Core.Creational.ObjectPool;
using Patterns.Tests.TestTools;

namespace Patterns.Tests.Creational.Tests;

[TestFixture]
public class ObjectPoolTests
{
    Random random = new Random();
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Get_Then_Throws_Nothing()
    {
        var pool = new ObjectPool<Subject>(() => new Subject());
        Assert.That(pool.Get, Throws.Nothing);
    }

    [Test]
    public void Get_Then_Used_Count_Increases()
    {
        var pool = new ObjectPool<Subject>(() => new Subject());
        using (var pooledResource = pool.Get())
        {
            Assert.That(pool.UsedCount, Is.EqualTo(1));
        }
    }
    [Test]
    public void Get_When_Freed_Then_Used_Count_Is_Zero()
    {
        var pool = new ObjectPool<Subject>(() => new Subject());
        using (var pooledResource = pool.Get())
        {
            //Do some stuff
        }
        Assert.That(pool.UsedCount, Is.Zero);
    }

    [Test]
    public void Get_When_Multiple_Gets_Then_Instance_Gets_Reused()
    {
        int parameter = random.Next(20);
        var pool = new ObjectPool<Subject>(() => new Subject());
        using (var pooledResource = pool.Get())
        {
            Subject subject = pooledResource;
            subject.IntProperty = parameter;
        }
        using var pooledResource2 = pool.Get();
        Assert.That(pooledResource2.Value.IntProperty, Is.EqualTo(parameter));
    }

    [Test]
    public void Get_When_Quota_Gets_Exceded_Then_Throws_Nothing()
    {
        var pool = new ObjectPool<Subject>(() => new Subject(), 0);
        Assert.That(pool.Get, Throws.InstanceOf<ObjectPoolQuotaExcededException>());
    }
}