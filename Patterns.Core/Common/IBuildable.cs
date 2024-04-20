
namespace Patterns.Core.Common;

public interface IBuildable<T, TParam>
{
    static abstract T Build(TParam parameter);
}

public interface IBuildable<T>
{
    static abstract T Build();
}