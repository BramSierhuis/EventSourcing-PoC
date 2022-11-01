namespace WidgetAndCo.Models.Events.Reviews;

public class ReviewCreated : BaseEvent
{
    public Guid ProductId { get; set; }
    public string Review { get; set; }
}