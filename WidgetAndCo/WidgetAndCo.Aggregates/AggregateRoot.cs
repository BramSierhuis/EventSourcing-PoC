using WidgetAndCo.Messages.Events;

namespace WidgetAndCo.Aggregates;

public abstract class AggregateRoot
{
    public Guid AggregateId { get; protected set; }
    public int Version { get; private set; }
    private readonly IList<IEvent> _uncommitedEvents;

    public AggregateRoot()
    {
        _uncommitedEvents = new List<IEvent>();
    }

    protected abstract void Mutate(object e);

    protected void Apply<TEvent>(Action<TEvent> action)
        where TEvent : IEvent
    {
        // Create a new instance
        var @event = Activator.CreateInstance<TEvent>();
        action.Invoke(@event);

        // Update the state
        Mutate(@event);

        // Add the event
        _uncommitedEvents.Add(@event);
        Version++;
    }

    public void ApplyIf<TEvent>(Func<object, bool> validateFunction, Action<TEvent> successAction)
        where TEvent : IEvent
    {
        var success = validateFunction.Invoke(this);

        if (success)
        {
            Apply(successAction);
        }
    }

    public void Hydrate(IEnumerable<object> events)
    {
        foreach (var @event in events)
        {
            Mutate(@event);
            Version++;
        }
    }

    public void Flush()
    {
        _uncommitedEvents.Clear();
    }

    public IEnumerable<IEvent> GetUncommittedEvents() => _uncommitedEvents;
}