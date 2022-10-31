namespace WidgetAndCo.Exceptions;

public class InvalidImageException : Exception
{
    public InvalidImageException()
    {
    }

    public InvalidImageException(string message)
        : base(message)
    {
    }
}