using BookStore.Graph.Database.Domain;
using BookStore.Graph.Database.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Graph.DataAccess.Repositories.Contracts
{
    public interface IPostService
    {
        IEnumerable<Post> GetPosts();
        IEnumerable<Comment> GetCommentsOfPost(Guid PostId);
        AppGraphUser GetIssuerOfPost(string PostId);
    }
}
