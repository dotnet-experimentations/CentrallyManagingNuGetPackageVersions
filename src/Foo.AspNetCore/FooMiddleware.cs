using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Foo.AspNetCore
{
    public class FooMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IFooBar _foobar;

        public FooMiddleware(RequestDelegate next, IFooBar foobar)
        {
            _next = next;
            _foobar = foobar;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var inputStringValue = httpContext.Request.Query["input"];
            if (!int.TryParse(inputStringValue, out var inputValue))
            {
                httpContext.Response.StatusCode = 400;
                return;
            }

            var foobarResult = _foobar.Compute(inputValue);
            
            httpContext.Response.StatusCode = 200;
            await httpContext.Response.WriteAsync(foobarResult).ConfigureAwait(false);
        }
    }
}
