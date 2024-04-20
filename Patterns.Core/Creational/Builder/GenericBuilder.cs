using Patterns.Core.Common;

namespace Patterns.Core.Creational.Builder;

public class GenericBuilder<T> : IBuilder<T> where T : new()
{
    public List<Action<T>> Steps { init; private get; } = [];

    T IBuilder<T>.Build()
    {
        T result = new();
        Steps.ForEach(step => step(result));
        return result;
    }
}
