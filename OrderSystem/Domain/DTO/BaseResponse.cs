namespace OrderSystem.Domain.DTO
{
    public class BaseResponse<T>
    {
        public int Code { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
    }
}
