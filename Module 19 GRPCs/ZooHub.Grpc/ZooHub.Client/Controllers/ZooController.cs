using Grpc.Core;
using Grpc.Net.Client;
using Grpc.Net.ClientFactory;

using Microsoft.AspNetCore.Mvc;

namespace ZooHub.Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ZooController : ControllerBase
    {
        private readonly ILogger<ZooController> logger;
        private Zoo.ZooClient _client;

        public ZooController(GrpcClientFactory grpcClientFactory, ILogger<ZooController> logger)
        {
            _client = grpcClientFactory.CreateClient<Zoo.ZooClient>("ZooClient");
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var animals = await _client.GetZooAnimalsAsync(new ZooRequest { AnimalId = 1 }, deadline: DateTime.UtcNow.AddSeconds(3));
                return Ok(animals);
            }
            catch (RpcException ex)
            {
                this.logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }

        }
    }
}
