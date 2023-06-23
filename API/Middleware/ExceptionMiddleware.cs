using Newtonsoft.Json;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Call the next middleware component in the pipeline
                await _next(context);


            }
            catch (Exception ex)
            {
                // Handle the exception
                // Log the exception, return a custom error response, etc.
                await HandleExceptionAsync(context, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            // Set the response status code
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Response.ContentType = "application/json";

            // Create an error response object
            var response = new
            {
                error = exception.Message
            };

            // Convert the response to JSON
            var jsonResponse = JsonConvert.SerializeObject(response);

            // Write the response to the HTTP response stream
            await context.Response.WriteAsync(jsonResponse);
        }
    }
}
