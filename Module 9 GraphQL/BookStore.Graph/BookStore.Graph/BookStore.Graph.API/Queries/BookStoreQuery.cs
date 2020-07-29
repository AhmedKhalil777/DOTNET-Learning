using BookStore.Graph.DataAccess.Repositories.Contracts;
using BookStore.Graph.Types.QueryTypes;
using GraphQL.Types;

namespace BookStore.Graph.API.Queries
{
    [GraphQL.GraphQLMetadata("BookStore")]
    public class BookStoreQuery : ObjectGraphType
    {
        
        public BookStoreQuery(IPostService postService)
        {
            Field<ListGraphType<PostType>>(
                "posts",
                resolve: context => postService.GetPosts()
                );
        }
    }
}
