using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionTest
{
    using System;
    using System.Threading.Tasks;
    using global::Functions.DurableFunctions.Helpers;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.DurableTask;
    using Microsoft.Extensions.Logging;

    namespace Functions.DurableFunctions
    {
        public class DurableServiceBusFunction
        {
            private readonly ILogger<DurableServiceBusFunction> _logger;
            private readonly ServiceBusHelper serviceBus;

            public DurableServiceBusFunction(ILogger<DurableServiceBusFunction> logger, ServiceBusHelper serviceBus)
            {
                _logger = logger;
                this.serviceBus = serviceBus;
            }

            [FunctionName(nameof(DurableProcess))]
            public async Task DurableProcess(
                [ServiceBusTrigger("durableprocess", Connection = "ServiceBusConnection")] Job msg,
                [DurableClient] IDurableOrchestrationClient orchestrationClient)
            {
                _logger.LogInformation($"Received ExecuteAllocationsJob at: {DateTime.UtcNow}");

                // Start the durable orchestration
                string instanceId = await orchestrationClient.StartNewAsync(nameof(DurableProcessOrchestrator), msg);

                _logger.LogInformation($"Started durable function with ID: {instanceId}");
            }

            [FunctionName(nameof(DurableProcessOrchestrator))]
            public async Task DurableProcessOrchestrator(
                [OrchestrationTrigger] IDurableOrchestrationContext context)
            {
                var msg = context.GetInput<Job>();

                _logger.LogInformation($"Orchestrator started for Job: {msg.JobId}");

                // Call activity function
                await context.CallActivityAsync(nameof(DurableActivity), msg);

                _logger.LogInformation($"Orchestrator completed for Job: {msg.JobId}");
            }

            [FunctionName(nameof(DurableActivity))]
            public async Task DurableActivity(
                [ActivityTrigger] Job msg)
            {
                _logger.LogInformation($"Executing job {msg.JobId} at: {DateTime.UtcNow}");
                await Task.Delay(TimeSpan.FromMinutes(20));
                _logger.LogInformation($"Completed job {msg.JobId} at: {DateTime.UtcNow}");
            }
        }
    }

}
