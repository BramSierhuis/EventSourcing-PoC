namespace WidgetAndCo.Models.ReadModels;

public class ReviewReadModel : ReadModel
{
    public Guid ProductId { get; set; }
    public string Review { get; set; }
}