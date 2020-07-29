using GraphQL.Types;

namespace GraphQL.Sample.Types.Mutations
{
    public class PropertyInputType : InputObjectGraphType
    {
        public PropertyInputType()
        {
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<StringGraphType>("street");
            Field<StringGraphType>("city");
            Field<StringGraphType>("family");
            Field<DecimalGraphType>("value");
        }
    }

}
