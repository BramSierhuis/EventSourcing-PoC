namespace WidgetAndCo.Models.Commands.Customers;

public class CreateCustomer : ICommand
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public ShippingAddress ShippingAddress { get; set; }
}