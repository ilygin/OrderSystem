namespace OrderSystem.Domain.DTO
{
    public class BaseResonse<T>
    {
        public int Code { get; set; }
        public int Message { get; set; }
        public T? Data { get; set; }
    }
}
