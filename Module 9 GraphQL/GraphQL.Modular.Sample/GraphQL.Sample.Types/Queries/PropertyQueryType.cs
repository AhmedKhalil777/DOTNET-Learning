using GraphQL.Sample.DataAccess.Repositories.Contracts;
using GraphQL.Sample.Database.Model;
using GraphQL.Types;

namespace GraphQL.Sample.Types
{

    [GraphQLMetadata("Property", IsTypeOf = typeof(Property))]
    public class PropertyQueryType : ObjectGraphType<Property>
    {
        public PropertyQueryType(IPaymentRepository paymentRepository)
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Value);
            Field(x => x.City);
            Field(x => x.Street);
            Field(x => x.Family);
            Field<ListGraphType<PaymentQueryType>>(
                "payments",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name ="last"}),
                resolve: context => {
                    var lastItemFilter = context.GetArgument<int?>("last");
                    return lastItemFilter != null ? paymentRepository.GetAllPaymentsProperty(context.Source.Id, lastItemFilter.Value)
                    : paymentRepository.GetAllPaymentsProperty(context.Source.Id);

                }) ;
            
        }
    }
}
