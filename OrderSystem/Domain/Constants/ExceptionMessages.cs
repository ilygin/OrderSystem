namespace OrderSystem.Domain.Constants
{
    public static class ExceptionMessages
    {
        public static string OrderNotFound = "Order with ID {0} not found.";
        public static string InvalidOrderOperation = "Cannot perform '{0}' because order is in '{1}'";
    }
}
