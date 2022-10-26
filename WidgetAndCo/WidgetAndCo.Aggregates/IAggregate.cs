namespace WidgetAndCo.Aggregates;

public interface IAggregate<TId>
{
    TId Id { get; }
}