using WidgetAndCo.Aggregates;

namespace WidgetAndCo.Repositories;

public class EventStore<T, TId> : IAggregateStore<T, TId> where T: AggregateRoot<TId> 
{
    public Task<bool> Exists(TId aggregateId)
    {
        throw new NotImplementedException();
    }

    public Task Save(T aggregate)
    {
        throw new NotImplementedException();
    }

    public Task<T> Load(TId aggregateId)
    {
        if (aggregateId == null)
            throw new ArgumentNullException(nameof(aggregateId));
        
        var aggregate = (T) Activator.CreateInstance(typeof(T), true);

        throw new NotImplementedException();
    }
}