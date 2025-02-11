using Functions.DurableFunctions.Helpers;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Functions.DurableFunctions
{
    public class SendTimerNotifcationFunction
    {
        private readonly ILogger<SendTimerNotifcationFunction> _logger;
        private readonly ServiceBusHelper serviceBus;
        static int jobId = 1;
        public SendTimerNotifcationFunction(ILogger<SendTimerNotifcationFunction> logger, ServiceBusHelper serviceBus)
        {
            _logger = logger;
            this.serviceBus = serviceBus;
        }

        [Function(nameof(SendNotification))]
        public async Task SendNotification([TimerTrigger("*/59 * * * *", RunOnStartup = true)] TimerInfo timerInfo)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            await this.serviceBus.SendMessageAsync(new JobMessage
            {
                QueueName = "durableprocess",
                Content = JsonSerializer.Serialize(new Job { JobId = jobId, DurationInMinutes = 10 }),
                JobId = jobId
            });
            jobId++;
        }

    }



}
