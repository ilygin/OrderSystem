namespace OrderSystem.Domain.DTO
{
    public class OrderRequestDto
    {
        public string? CustomerName {  get; set; }
        public decimal? TotalAmount { get; set; }
        public int? Count { get; set; }
    }
}
