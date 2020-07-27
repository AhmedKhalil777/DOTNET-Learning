using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Sample.Types;
using GraphQL.Sample.DataAccess.Repositories.Contracts;

namespace GraphQL.Sample.API.Queries
{
    public class PropertyQuery : ObjectGraphType
    {
        public PropertyQuery(IPropertyRepository propertyRepository)
        {
            Field<ListGraphType<PropertyType>>(
                "Properties",
                resolve: context => propertyRepository.GetAll());
        }
    }
}
