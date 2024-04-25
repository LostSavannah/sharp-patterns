namespace Patterns.Core.Behavioral.Memento;

public interface IMementoSubject<T>
{
    IMemento<T> CreateSnapshot(string name); 
}
