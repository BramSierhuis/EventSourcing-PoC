namespace WidgetAndCo.Models;

public class CustomerId
{
    public Guid Value { get; private set; }

    public CustomerId(Guid id)
    {
        Value = id;
    }

    public static implicit operator Guid(CustomerId self) => self.Value;

    public static implicit operator CustomerId(Guid value)
        => new(value);

    public override string ToString() => Value.ToString();
}