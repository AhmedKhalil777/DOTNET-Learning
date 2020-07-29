using GraphQL.Sample.Database.Model;
using GraphQL.Types;

namespace GraphQL.Sample.Types
{
    [GraphQLMetadata("Payment", IsTypeOf = typeof(Payment))]
    public class PaymentQueryType : ObjectGraphType<Payment>
    {
        //[GraphQLMetadata("Droid", IsTypeOf = typeof(Property))]
        public PaymentQueryType()
        {
            Field(x => x.Id);
            Field(x => x.Value);
            Field(x => x.IssueDate);
            Field(x => x.OverDueDate);
            Field(x => x.IsPaid);
        }
    }
}
