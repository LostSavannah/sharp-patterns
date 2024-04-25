using Patterns.Core.Behavioral.Memento;
using Patterns.Core.Common;
using Patterns.Core.Creational.Singleton;

namespace Patterns.Tests.TestTools;

internal class Subject : 
    ISubject, IBuildable<Subject>, IBuildable<Subject, int>, ISingleton<Subject>,
    IMementoSubject<Subject>
{
    public const int InitialIntPropertyValue = 10;
    public int IntProperty { get; set; } = InitialIntPropertyValue;

    static Subject IBuildable<Subject>.Build() => new Subject();
    static Subject IBuildable<Subject, int>.Build(int parameter) => new Subject()
    {
        IntProperty = parameter
    };

    public IMemento<Subject> CreateSnapshot(string name) => new SubjectMemento(name, this);

    int ISubject.GetSubjectThings() => IntProperty;

    class SubjectMemento : Memento<Subject>
    {
        int intProperty;
        public SubjectMemento(string name, Subject subject): base(name)
        {
            intProperty = subject.IntProperty;
        }
        public override void Restore(Subject subject)
        {
            subject.IntProperty = intProperty;
        }
    }
}
