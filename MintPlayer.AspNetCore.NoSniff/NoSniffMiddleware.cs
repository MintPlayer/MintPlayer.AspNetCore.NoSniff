namespace MintPlayer.AspNetCore.NoSniff
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class NoSniffMiddleware
    {
        private readonly RequestDelegate next;

        public NoSniffMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await next(httpContext);
            httpContext.Response.Headers.XContentTypeOptions = "nosniff";
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class NoSniffMiddlewareExtensions
    {
        public static IApplicationBuilder UseNoSniffMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<NoSniffMiddleware>();
        }
    }
}
