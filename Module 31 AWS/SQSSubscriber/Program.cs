// See https://aka.ms/new-console-template for more information
using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;

var cts = new CancellationTokenSource();

var sqsClient = new AmazonSQSClient(RegionEndpoint.USEast1);

var queueUrlResponse = await sqsClient.GetQueueUrlAsync("customer");

var recieveMessageRequesgt = new ReceiveMessageRequest
{
    QueueUrl = queueUrlResponse.QueueUrl,
    AttributeNames = new List<string> { "All"},
    MessageAttributeNames = new List<string> { "All"}
};
while (!cts.IsCancellationRequested)
{
    var response = await sqsClient.ReceiveMessageAsync(recieveMessageRequesgt, cts.Token);
    foreach (var message in response.Messages)
    {
        Console.WriteLine(message.MessageId);
        Console.WriteLine(message.Body);

        await sqsClient.DeleteMessageAsync(queueUrlResponse.QueueUrl, message.ReceiptHandle, cts.Token);
    }
    await Task.Delay(1000);
}