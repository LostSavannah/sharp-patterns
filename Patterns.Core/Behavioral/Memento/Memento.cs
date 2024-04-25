namespace Patterns.Core.Behavioral.Memento;

public abstract class Memento<T>(string name) : IMemento<T>
{
    public string Name { get; } = name;

    public DateTime CreateDate { get; } = DateTime.Now;

    public abstract void Restore(T subject);
}
