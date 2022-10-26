using WidgetAndCo.Aggregates;

namespace WidgetAndCo;

public interface IAggregateStore<T, TId> where T: AggregateRoot<TId>
{
    Task<bool> Exists(TId aggregateId);
    Task Save(T aggregate);
    Task<T> Load(TId aggregateId);
}