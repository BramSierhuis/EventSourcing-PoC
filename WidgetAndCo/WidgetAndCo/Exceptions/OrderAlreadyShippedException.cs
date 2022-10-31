namespace WidgetAndCo.Exceptions;

public class OrderAlreadyShippedException : Exception
{
    public OrderAlreadyShippedException()
    {
    }

    public OrderAlreadyShippedException(string message)
        : base(message)
    {
    }
}