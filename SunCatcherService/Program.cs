using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet.Core.Camerapi;
using Dotnet.Core.Camerapi.Internal;
using Dotnet.Core.Camerapi.Impl;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SunCatcherService.Impl;

namespace SunCatcherService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<IImageParametersBuilder>(new ImageParametersBuilder());
                    services.AddSingleton<ICameraPi>((provider) => new CameraPiModule(provider.GetRequiredService<IImageParametersBuilder>()));
                    services.AddSingleton<ISunCatcherWorkerService>((provider) => new SunCatcherWorkerService(provider.GetRequiredService<ICameraPi>()));
                    services.AddHostedService<Worker>();
                });
    }
}
