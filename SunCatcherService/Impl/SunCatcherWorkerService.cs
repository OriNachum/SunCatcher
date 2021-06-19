using System;
using Dotnet.Core.Camerapi;
using Dotnet.Core.Camerapi.Models;

namespace SunCatcherService.Impl
{
    public class SunCatcherWorkerService : ISunCatcherWorkerService
    {
        private readonly ICameraPi _camerapi;

        public SunCatcherWorkerService(ICameraPi camerapi)
        {
            _camerapi = camerapi;
        }

        public void DoYourStuff()
        {
            _camerapi.CaptureImage(new ImageParameters{
                Output = "test.jpeg",
            });
        }
    }
}