using GraphQL.Sample.DataAccess.Repositories.Contracts;
using GraphQL.Sample.Database.Model;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Sample.Types
{
    public class PropertyType : ObjectGraphType<Property>
    {
        public PropertyType(IPaymentRepository paymentRepository)
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Value);
            Field(x => x.City);
            Field(x => x.Street);
            Field(x => x.Family);
            Field<ListGraphType<PaymentType>>(
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
