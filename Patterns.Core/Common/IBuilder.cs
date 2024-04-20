namespace Patterns.Core.Common;

public interface IParametrizedBuilder<T, TParam>
{
    T Build(TParam parameter);
}
public interface IParametrizedBuilder<T, TResult, TParam> : IParametrizedBuilder<TResult, TParam> where T : TResult { }

public interface IBuilder<T>
{
    T Build();
}

public interface IBuilder<T, TResult>: IBuilder<TResult> where T : TResult { }