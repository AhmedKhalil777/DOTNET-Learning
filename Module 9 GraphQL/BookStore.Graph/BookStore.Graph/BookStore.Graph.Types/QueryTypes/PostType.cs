using BookStore.Graph.DataAccess.Repositories.Contracts;
using BookStore.Graph.Database.Domain;
using BookStore.Graph.Database.Domain.Contracts;
using GraphQL;
using GraphQL.Instrumentation;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
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
            //Field(x=> x.Comments );
            Field<ListGraphType<CommentType>>("comments",
                Description = "Comments of A post",
                resolve: context => context.Source.Comments
                );
            Field<StringGraphType>(
                "id",
                Description = "id of a post",
                resolve: context =>  context.Source.Id.ToString()
                );

            Field<UserType>(
              "user",
              Description = "Issuer of a post",
              resolve: context => context.Source.User.Project()
              );

        }
    }
}
