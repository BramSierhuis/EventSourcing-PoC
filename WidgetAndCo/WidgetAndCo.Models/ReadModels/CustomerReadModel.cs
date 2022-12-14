namespace WidgetAndCo.Models.ReadModels;

public class CustomerReadModel : ReadModel
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public ShippingAddress ShippingAddress { get; set; }
}