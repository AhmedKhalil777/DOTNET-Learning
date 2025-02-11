using Functions.DurableFunctions.Helpers;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions.DurableFunctions
{
    public class RegularServiceBusFunction
    {
        private readonly ILogger<SendTimerNotifcationFunction> _logger;
        private readonly ServiceBusHelper serviceBus;
        static int jobId = 1;
        public RegularServiceBusFunction(ILogger<SendTimerNotifcationFunction> logger, ServiceBusHelper serviceBus)
        {
            _logger = logger;
            this.serviceBus = serviceBus;
        }


        //[Function(nameof(ProcessRegular))]
        //public async Task ProcessRegular([ServiceBusTrigger("processregular", Connection = "ServiceBusConnection")] Job msg)
        //{

        //    _logger.LogInformation($"C# Process Regular trigger function executed at: {DateTime.Now}");
        //    await Task.Delay(TimeSpan.FromMinutes(10));
        //    jobId++;
        //}

    }
}
