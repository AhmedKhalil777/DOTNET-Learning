using GraphQL.Sample.API.Queries;
using GraphQL.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL.Sample.API.Schemas
{
    public class RealEstateSchema : GraphQL.Types.Schema
    {
        public RealEstateSchema(IDependencyResolver resolver)
            :base(resolver)
        {
            Query = resolver.Resolve<PropertyQuery>();
        }
    }
}
