namespace OrderSystem.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string? CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
    }
}