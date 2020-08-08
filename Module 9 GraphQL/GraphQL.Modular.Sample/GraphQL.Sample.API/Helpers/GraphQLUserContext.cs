using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GraphQL.Sample.API.Helpers
{

        public class GraphQLUserContext : Dictionary<string, object>
        {
            public ClaimsPrincipal User { get; set; }
        }
    
}
