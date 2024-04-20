namespace Patterns.Core.Creational.ObjectPool;

public class ObjectPool<T>(Func<T> create, int quota = 5)
{
    record Instance(T Value)
    {
        public bool Used { get; set; }
    }
    Func<T> Create { get; } = create;
    public int UsedCount => instances.Count(c => c.Value.Used);

    readonly Random random = new();
    
    readonly Dictionary<string, Instance> instances = [];

    public PooledResource Get()
    {
        lock(instances)
        {
            var freeInstances = instances.Where(kv => !kv.Value.Used).ToList();
            if (freeInstances.Any())
            {
                string id = freeInstances.First().Key;
                instances[id].Used = true;
                return new PooledResource(this, id, instances[id].Value);
            }
            else if(instances.Count < quota)
            {
                string id = Guid.NewGuid().ToString();
                instances[id] = new Instance(Create()) { Used = true };
                return new PooledResource(this, id, instances[id].Value);
            }
            throw new ObjectPoolQuotaExcededException();
        }
    }

    private void Free(string id)
    {
        lock (instances)
        {
            instances[id].Used = false;
        }
    }
    public class PooledResource(ObjectPool<T> pool, string id, T value) : IDisposable
    {
        public T Value { get; } = value;
        public void Dispose()
        {
            pool.Free(id);
        }

        public static implicit operator T(PooledResource r) => r.Value;
    }
}