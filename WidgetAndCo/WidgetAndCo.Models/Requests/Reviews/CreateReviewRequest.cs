using System.ComponentModel.DataAnnotations;

namespace WidgetAndCo.Models.Requests.Reviews;

public class CreateReviewRequest
{
    [Required]
    public string Review { get; set; }
}