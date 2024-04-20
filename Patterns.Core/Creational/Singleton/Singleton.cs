namespace Patterns.Core.Creational.Singleton;

public class Singleton<T> : ISingleton<T> where T : ISingleton<T>, new()
{
    public static T Instance => ISingleton<T>.Instance;
}

public class Singleton<T, TResult> : ISingleton<T, TResult> where T : TResult, new ()
{
    public static TResult Instance => ISingleton<T, TResult>.Instance;
}
