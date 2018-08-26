using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace mvc0826.Middlewares
{
    public class FirstMiddleware
    {
        private readonly RequestDelegate _next;
        
        public FirstMiddleware(RequestDelegate next)
        {
            this._next = next;
        }
        
        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync($"{nameof(FirstMiddleware)} in. \r\n");

            await _next(context);

            await context.Response.WriteAsync($"{nameof(FirstMiddleware)} out. \r\n");
        }
    }
}