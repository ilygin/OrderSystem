namespace OrderSystem.Domain.Models
{
    //TODO: Add product and customer tables.
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string? CustomerName { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
