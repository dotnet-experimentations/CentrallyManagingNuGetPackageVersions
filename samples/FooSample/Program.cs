using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

#if NETCOREAPP2_1
using Microsoft.AspNetCore;
#endif

namespace FooSample
{

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

#if NETCOREAPP2_1
        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .UseStartup<Startup>();
#else
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
#endif
    }
}
