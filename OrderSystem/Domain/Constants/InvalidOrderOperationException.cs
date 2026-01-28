using OrderSystem.Domain.Exceptions;

namespace OrderSystem.Domain.Constants
{
    public class InvalidOrderOperationException(string opperation, string status) : OrderSystemException(string.Format(ExceptionMessages.InvalidOrderOperation, opperation, status), 400)
    {
    }
}
