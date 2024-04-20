using Patterns.Core.Common;
using Patterns.Core.Creational.Builder;
using Patterns.Tests.TestTools;

namespace Patterns.Tests;

[TestFixture]
public class GenericBuilderTests
{
    Random random = new Random();
    [SetUp]
    public void Setup()
    {
    }

    static List<Func<int, int>> mutators = [
            (n) => n+1, 
            (n) => n/2, 
            (n) => n*3, 
            (n) => n-4, 
            (n) => n%5,
            (n) => n == 0? 1:n,  
    ];

    [Test]
    public void Build_When_Empty_Generic_Builder_Builds_Then_Subject_Gets_Not_Mutated()
    {
        IBuilder<Subject> builder = new GenericBuilder<Subject>();
        Assert.That(builder.Build().IntProperty, Is.EqualTo(Subject.InitialIntPropertyValue));
    }

    [Test]
    [Repeat(100)]
    public void Build_When_Generic_Builder_Builds_Then_Steps_Gets_Applied_In_Order()
    {
        int mutatorsCount = random.Next(1, 10);
        int value = Subject.InitialIntPropertyValue;

        List<Func<int, int>> mutators = Enumerable
            .Range(0, random.Next(1, 10))
            .Select(_ => GenericBuilderTests.mutators[random.Next(0, GenericBuilderTests.mutators.Count)])
            .ToList();

        for(int n = 0; n < mutators.Count; n++)
        {
            value = mutators[n](value);
        }

        List<Action<Subject>> steps = mutators.Select<Func<int, int>, Action<Subject>>(m => (Subject b) => {
            b.IntProperty = m(b.IntProperty);
        }).ToList();

        IBuilder<Subject> builder = new GenericBuilder<Subject>()
        {
            Steps = steps
        };
        Assert.That(builder.Build().IntProperty, Is.EqualTo(value));
    }
}