namespace WidgetAndCo.Models.Events;

public abstract class BaseEvent : IEvent
{
    public Guid AggregateId { get; set; }
}