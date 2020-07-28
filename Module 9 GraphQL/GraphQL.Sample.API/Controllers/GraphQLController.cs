using Bogus.DataSets;
using GraphQL.Sample.Utilities;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Sample.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GraphQLController : ControllerBase
    {
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _documentExecuter;
        public GraphQLController(ISchema schema, IDocumentExecuter documentExecuter)
        {
            _documentExecuter = documentExecuter;
            _schema = schema;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] System.Text.Json.JsonElement rawQuery)
        {

            string rawJson = rawQuery.ToString();
            var query = JsonConvert.DeserializeObject<GraphQLQuery>(rawJson);
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }
            var inputs = query.Variables?.ToInputs();
            var executionOptions = new ExecutionOptions()
            {
                Schema = _schema,
                Query = query.Query,
                Inputs = inputs

            };

            var result = await _documentExecuter.ExecuteAsync(executionOptions);
            if (result.Errors?.Count() >0)
            {
                return BadRequest(result.Errors);
            }
            return Ok(result.Data);

        }
    }
}