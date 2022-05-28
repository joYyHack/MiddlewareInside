namespace MiddlewareInsideAspNetCore
{
    public class CustomMiddleware
    {
        readonly RequestDelegate next;

        public CustomMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync("\n\t\tstart 3");
            await next(context);
            await context.Response.WriteAsync("\n\t\tend 3");
        }
    }

    public static class CustomMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomMiddleware(this WebApplication app)
        {
            return app.UseMiddleware<CustomMiddleware>();
        }
    }
}
