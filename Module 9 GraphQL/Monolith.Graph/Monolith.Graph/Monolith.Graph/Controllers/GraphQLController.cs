using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Monolith.Graph;
using Monolith.Graph.Models;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;


namespace Monolith.Graph.Controllers
{
    public class GraphQLController  : Controller
    {
          [Route(Startup.GraphQlPath)]
        [Route(Startup.CustomGraphQlPath)]
     
            [HttpPost]
            public async Task<IActionResult> Post([FromBody] GraphQlQuery query)
            {
                var schema = new Schema { Query = new StarWarsQuery() };

                var result = await new DocumentExecuter().ExecuteAsync(x =>
                {
                    x.Schema = schema;
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

