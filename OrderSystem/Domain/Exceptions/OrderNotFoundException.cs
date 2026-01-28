using OrderSystem.Domain.Constants;

namespace OrderSystem.Domain.Exceptions
{
    public class OrderNotFoundException(int orderId) : OrderSystemException(string.Format(ExceptionMessages.OrderNotFound, orderId), 404)
    {
    }
}
