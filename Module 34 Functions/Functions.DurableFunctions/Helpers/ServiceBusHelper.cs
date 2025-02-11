using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions.DurableFunctions.Helpers
{
    public class ServiceBusHelper
    {

        private readonly ServiceBusClient _client;
        private readonly ServiceBusAdministrationClient _adminClient;
        private Dictionary<string, ServiceBusSender> _senders;
        public ServiceBusHelper(IConfiguration configuration)
        {
            // Retrieve the connection string from appsettings.json
            string connectionString = configuration.GetConnectionString("ServiceBusConnection");

            // Create a ServiceBusClient
            _client = new ServiceBusClient(connectionString);
            _adminClient = new ServiceBusAdministrationClient(connectionString);

            // Create a sender for the specified queue
            _senders = new Dictionary<string, ServiceBusSender>();
        }

        public async Task SendMessageAsync(JobMessage message)
        {
            ServiceBusSender sender;


            // Create a new message to send to the queue
            if (!_senders.ContainsKey(message.QueueName))
            {
                if (!await _adminClient.QueueExistsAsync(message.QueueName))
                {
                   await _adminClient.CreateQueueAsync(message.QueueName);
                }
                sender = _client.CreateSender(message.QueueName);
                _senders.Add(message.QueueName, sender);
            }
            else
            {
                sender = _senders[message.QueueName];
            }
            message.Body = BinaryData.FromString(message.Content);
            // Send the message to the queue
            await sender.SendMessageAsync(message);
            Console.WriteLine($"Sent a single message to the queue: {message.JobId}");
        }

        public async Task CloseAsync()
        {
            // Close the sender and client when finished
            foreach (var sender in _senders)
            {
              await sender.Value.DisposeAsync();
            }
            await _client.DisposeAsync();
        }
    }
}
