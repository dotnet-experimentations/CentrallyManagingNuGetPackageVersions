#if NETCOREAPP3_1 || NET5_0

using Foo.AspNetCore;
using Microsoft.AspNetCore.Routing;

namespace Microsoft.AspNetCore.Builder
{
    public static class FooEndpointRouteBuilderExtensions
    {
        public static IEndpointRouteBuilder MapFoo(this IEndpointRouteBuilder endpoints)
        {
            var app = endpoints
                        .CreateApplicationBuilder()
                        .UseMiddleware<FooMiddleware>()
                        .Build();

            endpoints.MapGet("/foobar", app);

            return endpoints;
        }
    }
}

#endif
