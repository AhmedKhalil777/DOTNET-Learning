using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;
using SQSPublisher;
using System.Text.Json;

var sqsClient = new AmazonSQSClient(RegionEndpoint.USEast1);
var customer = new CustomerCreated
{
    CreatedAt = DateTime.Now,
    Email = "Progeng_ahmed_khalil@outlook.com",
    Name = "Ahmed Khalil",
    Id = Guid.NewGuid()
};

var queueUrlResponse = await sqsClient.GetQueueUrlAsync("customer");

var smr = new SendMessageRequest
{
    MessageAttributes = new Dictionary<string, MessageAttributeValue>
    {
        ["Type"] = new MessageAttributeValue { 
            StringValue  = nameof(CustomerCreated),
            DataType = "String"
        }
    },
    QueueUrl = queueUrlResponse.QueueUrl,
    MessageBody = JsonSerializer.Serialize(customer)
};

var res = await sqsClient.SendMessageAsync(smr);

Console.WriteLine("Sent");

Console.ReadLine();