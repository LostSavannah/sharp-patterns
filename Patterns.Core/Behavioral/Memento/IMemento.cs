namespace Patterns.Core.Behavioral.Memento;

public interface IMemento<T>
{
    public string Name { get; }
    public DateTime CreateDate { get; }
    void Restore(T subject);
}
