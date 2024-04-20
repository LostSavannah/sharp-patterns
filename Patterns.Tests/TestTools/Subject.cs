using Patterns.Core.Common;
using Patterns.Core.Creational.Singleton;

namespace Patterns.Tests.TestTools;

internal class Subject : ISubject, IBuildable<Subject>, IBuildable<Subject, int>, ISingleton<Subject>
{
    public const int InitialIntPropertyValue = 10;
    public int IntProperty { get; set; } = InitialIntPropertyValue;

    static Subject IBuildable<Subject>.Build() => new Subject();
    static Subject IBuildable<Subject, int>.Build(int parameter) => new Subject()
    {
        IntProperty = parameter
    };

    int ISubject.GetSubjectThings() => IntProperty;
}
