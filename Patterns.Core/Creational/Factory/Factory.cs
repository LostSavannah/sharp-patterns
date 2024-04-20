using Patterns.Core.Common;

namespace Patterns.Core.Creational.Factory;

public class Factory<T> : IFactory<T> where T : IBuildable<T>
{
    T IFactory<T>.Create() => T.Build();
}
public class Factory<T, TParam> : IFactory<T>, IFactory<T, TParam> where T : IBuildable<T, TParam>
{
    public Factory(TParam defaultValue = default!)
    {
        DefaultValue = defaultValue;
    }

    private TParam DefaultValue { get; }

    public T Create() => T.Build(DefaultValue);

    public T Create(TParam param) => T.Build(param);
}
