using Bogus.DataSets;
using GraphQL.Sample.API.Queries;
using GraphQL.Sample.API.Schemas;
using GraphQL.Sample.DataAccess.Repositories.Contracts;
using GraphQL.Sample.Database;
using GraphQL.Sample.Utilities;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Sample.API.Controllers
{
    [Route(Startup.GraphQlPath)]
    [Route(Startup.CustomGraphQlPath)]
    public class GraphQLController : Controller
    {
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;
        private readonly IPropertyRepository _propertyRepository;

        public GraphQLController( IDocumentExecuter documentExecuter, IPropertyRepository propertyRepository , ISchema schema)
        {
           
            _documentExecuter = documentExecuter;
            _propertyRepository = propertyRepository;
            _schema = schema;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query /**System.Text.Json.JsonElement rawQuery**/ )
        {
           // string rawJson = rawQuery.ToString();
           // var query = JsonConvert.DeserializeObject<GraphQLQuery>(rawJson);
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

           
  

            var result = await _documentExecuter
                .ExecuteAsync(new ExecutionOptions
                {
                    Schema = _schema,
                    Query = query.Query,
                    Inputs = query.Variables
                });

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result.Data);
        }
    }
}