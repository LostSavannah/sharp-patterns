namespace Patterns.Core.Creational.Factory;

public interface IFactory<T>
{
    T Create();
}
public interface IFactory<T, TParam>
{
    T Create(TParam parameter);
}
