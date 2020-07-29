using BookStore.Graph.Database.Domain;
using GraphQL;
using GraphQL.Instrumentation;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BookStore.Graph.Types.QueryTypes
{
    public class PostType : ObjectGraphType<Post>
    {
        public PostType()
        {
            Field(x => x.Head).Description("The Post Header");
            Field(x => x.Body).Description("The Post Body");
            Field(x => x.Likes).Description("The Post Number of likes");
            Field<ListGraphType<CommentType>>(
                "comments",
                resolve: context => {
                    return context.GetPropertyValue("Comments");
                });
        }
    }
}
