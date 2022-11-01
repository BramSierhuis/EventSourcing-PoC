namespace WidgetAndCo.Models.Commands.Reviews;

public class CreateReview : ICommand
{
    public Guid ProductId { get; set; }
    public string Review { get; set; }
}