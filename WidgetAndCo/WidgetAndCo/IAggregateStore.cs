using WidgetAndCo.Aggregates;

namespace WidgetAndCo;

public interface IAggregateStore<T> where T: AggregateRoot
{
    Task<bool> Exists(Guid aggregateId);
    Task Save(T aggregate);
    Task<T> Load(Guid aggregateId);
}