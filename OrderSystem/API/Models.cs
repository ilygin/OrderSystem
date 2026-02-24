namespace OrderSystem.API
{
    public abstract class APIResponse
    {
        public string Title { get; set; } =  string.Empty;
        public int Status { get; set; }
        public string Detail { get; set; } = string.Empty;
        public string Instance { get; set; } = string.Empty;
    }
    public class APIErrorResponse : APIResponse
    {
        public Dictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
    }

    public class APISuccessResponse<T> : APIResponse
    {
        public T? Data { get; set; }
    }
}
