using BookStore.Graph.API.Queries;
using BookStore.Graph.Utilities;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Graph.API.Controllers
{
    public class GraphQLController: Controller
    {
        private readonly ISchema _schema;
        public GraphQLController(ISchema schema)
        {

            _schema = schema;
        }

        [Route(Startup.GraphQlPath)]
        [Route(Startup.CustomGraphQlPath)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
          
            var result = await new DocumentExecuter().ExecuteAsync(x =>
            {
                x.Schema = _schema;
                x.Query = query.Query;
                x.Inputs = query.Variables;
            });

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
