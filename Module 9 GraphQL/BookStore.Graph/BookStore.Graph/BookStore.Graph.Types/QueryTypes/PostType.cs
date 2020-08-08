using BookStore.Graph.DataAccess.Repositories.Contracts;
using BookStore.Graph.Database.Domain;
using BookStore.Graph.Database.Domain.Contracts;
using GraphQL;
using GraphQL.Instrumentation;
using GraphQL.Types;

namespace BookStore.Graph.Types.QueryTypes
{
    public class PostType : ObjectGraphType<Post>
    {
         public PostType(IPostService postService)
        {

            Field<StringGraphType>(
                         "id",
                         Description = "id of a post",
                         resolve: context => context.Source.Id.ToString());
            Field(x => x.Head).Description("The Post Header");
            Field(x => x.Body).Description("The Post Body");
            Field(x => x.Likes).Description("The Post Number of likes");
            Field<ListGraphType<CommentType>>("comments",
                Description = "Comments of A post",
                resolve: context => context.Source.Comments);
            Field<UserType>("user",
                Description = "User",
                resolve: ctx => postService.GetIssuerOfPost(ctx.Source.Id.ToString())
                );
            //Field<UserType>(
            //  "user",
            //  Description = "Issuer of a post",
            //  resolve: context => postService.GetIssuerOfPost(context.Source.Id));

        }
    }
}
