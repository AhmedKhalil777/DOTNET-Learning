using Grpc.Core;

using ZooHub.Grpc;
namespace ZooHub.Grpc.Services
{
    public class ZooService : Zoo.ZooBase
    {
        private readonly ILogger<ZooService> _logger;

        public ZooService(ILogger<ZooService> logger)
        {
            _logger = logger;
        }

        public override Task<AnimalResponse> GetZooAnimals(ZooRequest request, ServerCallContext context)
        {
            _logger.LogInformation("Sending Animals");
            var response = new AnimalResponse();
            // Deadlines
            // Task.Delay(4000).Wait();
            response.Animals.AddRange(new List<Animal>{
                new Animal
            {
                Class = "Dog",
                Id =1,
                Name="Roy"
            },
                new Animal
                {
                    Id = 2,
                    Class="Cat",
                    Name = "SOSO"
                }
            });
            return Task.FromResult(response);
        }
    }
}
