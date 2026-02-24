using OrderSystem.Domain.Exceptions;

namespace OrderSystem.API
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public  ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (OrderNotFoundException ex)
            {
                await HandleExceptionAsync(context, ex.Message, 404, "Order Not Found");
            }
            catch (OrderValidationException ex)
            {
                await HandleExceptionAsync(context, ex.Message, 400, "Order Validation Failed");
            }
            catch (InvalidOrderOperationException ex)
            {
                await HandleExceptionAsync(context, ex.Message, 400, "Invalid Order Operation");
            }
            catch (OrderSystemException ex)
            {
                await HandleExceptionAsync(context, ex.Message, ex.StatusCode, "Order System Error");
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex.Message, StatusCodes.Status500InternalServerError, "An unexpected error occurred");
            }
        }
        private static async Task HandleExceptionAsync(HttpContext context, string message, int code, string title)
        {
            var error = new APIErrorResponse
            {
                Title = title,
                Status = code,
                Detail = message,
                Instance = context.Request.Path
            };
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;
            await context.Response.WriteAsJsonAsync(error);
        }
    }
}
