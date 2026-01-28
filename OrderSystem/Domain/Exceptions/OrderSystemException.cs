namespace OrderSystem.Domain.Exceptions
{
    public class OrderSystemException : Exception
    {
        public int StatusCode { get; }
        public OrderSystemException(string message, int code) : base(message)
        {
            StatusCode = code;
        }
    }
}
