namespace WidgetAndCo.Exceptions;

public class ReviewNotFoundException : Exception
{
    public ReviewNotFoundException()
    {
    }

    public ReviewNotFoundException(string message) : base(message)
    {
    }
}