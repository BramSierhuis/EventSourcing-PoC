using System.ComponentModel.DataAnnotations;

namespace WidgetAndCo.Models.Requests;

public class CreateReviewRequest
{
    [Required]
    public string Review { get; set; }
}