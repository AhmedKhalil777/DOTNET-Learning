using GraphQL.Sample.DataAccess.Repositories.Contracts;
using GraphQL.Sample.Database.Model;
using GraphQL.Sample.Types;
using GraphQL.Sample.Types.Mutations;
using GraphQL.Types;


namespace GraphQL.Sample.API.Mutations
{
    public class PropertyMutation : ObjectGraphType
    {
        public PropertyMutation(IPropertyRepository propertyRepository)
        {
            Field<PropertyQueryType>(
                "addProperty",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PropertyInputType>> { Name= "property" }
                    ),
                resolve: context =>
                {
                    Property property = context.GetArgument<Property>("property");
                   Property result = propertyRepository.AddProperty(property);
                    return result;

                    }
                );

        }
    }
}
