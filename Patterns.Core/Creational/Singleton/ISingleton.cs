namespace Patterns.Core.Creational.Singleton;

public interface ISingleton<T> where T : new()
{
    private static T? instance;
    public static T Instance => instance ??= new();
}
public interface ISingleton<T, TResult> where T : TResult, new()
{
    private static T? instance;
    public static TResult Instance => instance ??= new();
}
