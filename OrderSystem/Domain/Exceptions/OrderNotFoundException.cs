using OrderSystem.Domain.Constants;

namespace OrderSystem.Domain.Exceptions
{
    public class OrderNotFoundException(Guid orderId) : OrderSystemException(string.Format(ExceptionMessages.OrderNotFound, orderId), 404)
    {
    }
}
