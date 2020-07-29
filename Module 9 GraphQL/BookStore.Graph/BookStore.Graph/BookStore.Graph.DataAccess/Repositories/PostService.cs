using BookStore.Graph.DataAccess.Repositories.Contracts;
using BookStore.Graph.Database;
using BookStore.Graph.Database.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Graph.DataAccess.Repositories
{
    public class PostService : IPostService
    {
        private readonly BookStoreDbContext _db;
        public PostService(BookStoreDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Post> GetPosts() => _db.Posts.Include(x => x.User).Include(x => x.Comments).ToList();
    }
}
