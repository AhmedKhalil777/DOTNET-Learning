using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace WebHook.Sample.Framework
{
    [ApiController, Route("{prefix:webhookRoutePrefix}/[controller]")]
    public abstract class AcceptedHandler<TRequest>
    {
        [HttpPost, Route(""), Status(HttpStatusCode.Accepted)]
        public abstract Task Handle([FromBody] TRequest request);
    }

    public class Status : ActionFilterAttribute
    {
        private readonly HttpStatusCode _statusCode;

        public Status(HttpStatusCode statusCode)
        {
            _statusCode = statusCode;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            context.Result = new StatusCodeResult((int)_statusCode);
        }
    }
}
