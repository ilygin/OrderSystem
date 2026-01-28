namespace OrderSystem.Domain.Exceptions
{
    public class OrderValidationException(string message) : OrderSystemException(message, 400)
    {
    }
}
