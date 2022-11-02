using WidgetAndCo.Aggregates;

namespace CommandHandler.Repositories.Abstract;

public interface IAggregateStore<T> where T: AggregateRoot
{
    Task<bool> Exists(Guid aggregateId);
    Task Save(T aggregate);
    Task<T> Load(Guid aggregateId);
}