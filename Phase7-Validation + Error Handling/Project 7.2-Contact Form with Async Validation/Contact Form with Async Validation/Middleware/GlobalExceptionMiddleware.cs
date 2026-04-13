

namespace Contact_Form_with_Async_Validation.Middleware
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public GlobalExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"An error occurred: {ex.Message}");

                var logPath = "errors.txt";
                var time = DateTime.Now;
                var action = context.Request.Path;
                var location = ex.StackTrace;
                var error = ex.Message;

                var logEntry = $"Time: {time}, Action: {action}, Location: {location}, Error: {error}";
                await File.AppendAllTextAsync(logPath, logEntry + Environment.NewLine);

                if (!context.Response.HasStarted)
                {
                    context.Response.Redirect("/Home/Error");
                }
            }
        }
    }
}
