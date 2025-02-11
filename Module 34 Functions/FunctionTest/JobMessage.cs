using Azure.Messaging.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functions.DurableFunctions.Helpers
{
    public class JobMessage : ServiceBusMessage
    {
        public int JobId { get; set; }
        public int DurationInMinutes { get; set; }

        public string Content { get; set; }

        public string QueueName { get; set; }
    }



    public class Job
    {
        public int JobId { get; set; }
        public int DurationInMinutes { get; set; }
    }
}
