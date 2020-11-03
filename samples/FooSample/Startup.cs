using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

#if NETCOREAPP3_1 || NET5_0
using Microsoft.Extensions.Hosting;
#endif

namespace FooSample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddFoo();
        }

#if NETCOREAPP2_1
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseFoo();
        }
#else
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapFoo();
            });
        }

#endif

    }
}
