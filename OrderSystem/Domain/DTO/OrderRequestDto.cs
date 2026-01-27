using OrderSystem.Domain.Enums;

namespace OrderSystem.Domain.DTO
{
    public class OrderRequestDto
    {
        public Guid Id { get; set; }
        public string? CustomerName {  get; set; }
        public decimal Amount { get; set; }
        public int Count { get; set; }
        public OrderStatus Status { get; set; }
    }
}
