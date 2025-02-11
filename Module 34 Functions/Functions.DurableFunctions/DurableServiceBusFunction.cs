using Functions.DurableFunctions.Helpers;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.DurableTask;
using Microsoft.DurableTask.Client;
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

        [Function(nameof(DurableProcess))]
        public async Task DurableProcess(
            [ServiceBusTrigger("durableprocess", Connection = "ServiceBusConnection")] Job msg,
            [DurableClient] DurableTaskClient client,
            FunctionContext executionContext)
        {
            _logger.LogInformation($"Received ExecuteAllocationsJob at: {DateTime.UtcNow}");

            // Function input comes from the request content.
            string instanceId = await client.ScheduleNewOrchestrationInstanceAsync(
                nameof(DurableProcessOrchestrator), msg, options: new StartOrchestrationOptions { InstanceId = msg.JobId.ToString() });

            _logger.LogInformation("Started orchestration with ID = '{instanceId}'.", instanceId);

        }

        [Function(nameof(DurableProcessOrchestrator))]
        public async Task DurableProcessOrchestrator([OrchestrationTrigger] TaskOrchestrationContext context)
        {
            var msg = context.GetInput<Job>();
            if (context.IsReplaying)
            {
                Console.WriteLine("Replaying Called......");
                return;
            }
            _logger.LogInformation($"Orchestrator started for Job: {msg.JobId}");

            // Call activity function
            await context.CallActivityAsync(nameof(DurableActivity), msg);

            _logger.LogInformation($"Orchestrator completed for Job: {msg.JobId}");
        }

        [Function(nameof(DurableActivity))]
        public async Task DurableActivity(
            [ActivityTrigger] Job msg, FunctionContext executionContext)
        {
            _logger.LogInformation($"Executing job {msg.JobId} at: {DateTime.UtcNow}");
            for (int i = 0; i < 6 * 30; i++)
            {
                await Task.Delay(TimeSpan.FromSeconds(10));
                Console.WriteLine((i+1) * 10);
            }
            _logger.LogInformation($"Completed job {msg.JobId} at: {DateTime.UtcNow}");
        }
    }
}