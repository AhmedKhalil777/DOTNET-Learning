using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebHook.Sample.Framework;
using WebHook.Sample.Models;

namespace WebHook.Sample.WebHooksHandlers
{
    public class Hello : ResponseHandler<HelloRequest, HelloResponse>
    {
        public async override Task<HelloResponse> Handle(HelloRequest request)
        {
            return new HelloResponse
            {
                Greeting = $"Hello, {request.Name}"
            };
        }
    }
}
