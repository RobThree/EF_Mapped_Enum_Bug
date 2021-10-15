using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EF_Mapped_Enum_Bug
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            using var host = CreateHostBuilder(args).Build();
            await host.RunAsync().ConfigureAwait(false);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureServices((ctx, services) =>
            {
                services.AddDbContext<TestContext>(options =>
                {
                    options.UseSqlServer(ctx.Configuration.GetConnectionString("Default"))
                        .LogTo(Console.WriteLine, LogLevel.Information);
                });
                services.AddHostedService<MyApp>();
            });
    }

    public class MyApp : IHostedService
    {
        public MyApp()
        {

        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Start");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Stop");
            return Task.CompletedTask;
        }
    }
}
