namespace Patterns.Core.Common;

public class ParametrizedBuilder<T, TParam> : IParametrizedBuilder<T, TParam> 
    where T : IBuildable<T, TParam>
{
    public T Build(TParam param) => T.Build(param);
}

public class ParametrizedBuilder<T, TResult, TParam> : IParametrizedBuilder<TResult, TParam> 
    where T : IBuildable<T, TParam>, TResult
{
    TResult IParametrizedBuilder<TResult, TParam>.Build(TParam parameter) => T.Build(parameter);
}

public class Builder<T> : IBuilder<T> where T : IBuildable<T>
{
    public T Build() => T.Build();
}
public class Builder<T, TResult> : IBuilder<TResult> where T : IBuildable<T>, TResult
{
    public TResult Build() => T.Build();
}