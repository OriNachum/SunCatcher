using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SunCatcherService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ISunCatcherWorkerService _sunCatcherWorkerService;

        public Worker(ILogger<Worker> logger, ISunCatcherWorkerService sunCatcherWorkerService)
        {
            _logger = logger;
            _sunCatcherWorkerService = sunCatcherWorkerService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                _sunCatcherWorkerService.DoYourStuff();
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
