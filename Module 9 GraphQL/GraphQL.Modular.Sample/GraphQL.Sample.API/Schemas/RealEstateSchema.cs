using GraphQL.Sample.API.Mutations;
using GraphQL.Sample.API.Queries;
 
namespace GraphQL.Sample.API.Schemas
{
    public class RealEstateSchema : GraphQL.Types.Schema
    {
        public RealEstateSchema(IDependencyResolver resolver)
            :base(resolver)
        {
            Query = resolver.Resolve<PropertyQuery>();
            Mutation = resolver.Resolve<PropertyMutation>();
        }
    }
}
