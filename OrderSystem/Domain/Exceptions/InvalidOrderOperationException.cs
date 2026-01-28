using OrderSystem.Domain.Constants;

namespace OrderSystem.Domain.Exceptions
{
    public class InvalidOrderOperationException(string operation, string status) : OrderSystemException(string.Format(ExceptionMessages.InvalidOrderOperation, operation, status), 400)
    {
    }
}
