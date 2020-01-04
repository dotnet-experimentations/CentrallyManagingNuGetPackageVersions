#if NETSTANDARD2_0

namespace Microsoft.AspNetCore.Builder
{
    public static class FooApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseFoo(this IApplicationBuilder app) => app;
    }
}

#endif
