using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TransientScopedSingleton.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransientScopedSingleton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private IMobileSingletonService _singleton;
        private IMobileScoppedService _scopped;
        private IMobileTransientService _transient;

        public HomeController(IMobileScoppedService scopped,IMobileSingletonService singleton, IMobileTransientService transient )
        {
            _singleton = singleton;
            _transient = transient;
            _scopped = scopped;
        }

        [HttpGet("Scopped")]
        public IEnumerable<Mobile> GetScopped()=> _scopped.GetAll();


        [HttpGet("Transient")]
        public IEnumerable<Mobile> GetTransient() => _transient.GetAll();

        [HttpGet("Singleton")]
        public IEnumerable<Mobile> GetSingleton() => _singleton.GetAll();


        [HttpPost("Scopped")]
        public IEnumerable<Mobile> PostScopped([FromBody] IEnumerable<Mobile> mobiles) {
            mobiles.ToList().ForEach(mobile => _scopped.Add(mobile));
            return _scopped.GetAll();
        }
        [HttpPost("Singleton")]
        public IEnumerable<Mobile> PostSingleton([FromBody] IEnumerable<Mobile> mobiles)
        {
            mobiles.ToList().ForEach(mobile => _singleton.Add(mobile));
            return _singleton.GetAll();
        }
        [HttpPost("Transient")]
        public IEnumerable<Mobile> PostTransient([FromBody] IEnumerable<Mobile> mobiles)
        {
            mobiles.ToList().ForEach(mobile => _transient.Add(mobile));
            return _transient.GetAll();
        }


    }
}
