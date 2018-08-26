using mvc0826.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace mvc0826.Extensions
{
    public static class CustomerMiddleware
    {
        public static IApplicationBuilder UseCustomerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<FirstMiddleware>();
        }
    }
}