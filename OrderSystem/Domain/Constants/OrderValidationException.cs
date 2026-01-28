using OrderSystem.Domain.Exceptions;

namespace OrderSystem.Domain.Constants
{
    public class OrderValidationException(string message) : OrderSystemException(message, 400)
    {
    }
}
