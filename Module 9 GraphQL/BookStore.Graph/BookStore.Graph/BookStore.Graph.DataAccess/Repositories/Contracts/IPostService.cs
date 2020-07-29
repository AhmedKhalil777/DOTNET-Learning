using BookStore.Graph.Database.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Graph.DataAccess.Repositories.Contracts
{
    public interface IPostService
    {
        IEnumerable<Post> GetPosts();
    }
}
