using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Collections.Generic;
using Foo;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class FooServiceCollectionExtensions
    {
        public static IServiceCollection AddFoo(this IServiceCollection services)
        {
            services.AddOptions<FooBarOptions>()
                    .PostConfigure(options =>
                    {
                        options.Mappings ??= new Dictionary<int, string> { { 3, "foo" }, { 5, "bar" } };
                    });

            services.TryAddTransient<IFooBar, FooBar>();

            return services;
        }
    }
}
