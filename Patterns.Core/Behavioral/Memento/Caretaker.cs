namespace Patterns.Core.Behavioral.Memento;

public class Caretaker<T>
{
    Stack<IMemento<T>> mementos = new();

    public IEnumerable<(string name, DateTime createDate)> Mementos => mementos.Select(m => (m.Name, m.CreateDate));

    public Caretaker<T> Add(IMemento<T> memento)
    {
        mementos.Push(memento);
        return this;
    }

    public Caretaker<T> Undo(T subject)
    {
        if(mementos.Count > 0)
        {
            mementos.Pop().Restore(subject);
        }
        return this;
    }
}
