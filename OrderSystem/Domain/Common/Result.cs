using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OrderSystem.Domain.Common
{
    public class Result<T>
    {
        private Result(bool isSuccess, T? body, string msg)
        {
            IsSuccess = isSuccess;
            Message = msg;
            Body = body;
        }

        public bool IsSuccess { set; get; }
        public string? Message { set; get; }
        public T? Body { set; get; }

        public static Result<T> Success(T? body)
        {
            return new Result<T>(true, body, string.Empty);
        }

        public static Result<T> Failure(T? body, string error)
        {
            return new Result<T>(false, body, error);
        }
    }

    public class Result
    {
        private Result(bool isSuccess, string msg)
        {
            IsSuccess = isSuccess;
            Message = msg;
        }

        public bool IsSuccess { set; get; }
        public string? Message { set; get; }

        public static Result Success()
        { 
            return new Result(true, string.Empty);
        }

        public static Result Failure(string error)
        {
            return new Result(false, error);
        }
    }
}
