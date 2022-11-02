using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace WidgetAndCo.Models.Requests.Products;

public class CreateProductRequest
{
    [Required]
    public string ProductName { get; set; }
    [Required]
    public double Price { get; set; }
    [Required]
    public IFormFile Image { get; set; }
}