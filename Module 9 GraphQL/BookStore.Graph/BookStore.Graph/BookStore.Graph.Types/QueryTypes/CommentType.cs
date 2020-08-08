using BookStore.Graph.Database.Domain;
using GraphQL.Types;

namespace BookStore.Graph.Types.QueryTypes
{
    public class CommentType : ObjectGraphType<Comment>
    {
        public CommentType()
        {
            Field(x => x.Body).Description("Body of Comment");
            //Field(x => x.Issuer).Description("Issuer of Comment");
        }
    }
}
