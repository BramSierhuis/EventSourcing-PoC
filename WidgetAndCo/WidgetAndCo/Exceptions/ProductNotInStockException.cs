namespace WidgetAndCo.Exceptions;

public class ProductNotInStockException : Exception
{
    public ProductNotInStockException()
    {
    }

    public ProductNotInStockException(string message)
        : base(message)
    {
    }
}