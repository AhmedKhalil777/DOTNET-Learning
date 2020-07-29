using BookStore.Graph.DataAccess.Repositories.Contracts;
using BookStore.Graph.Database;
using BookStore.Graph.Database.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace BookStore.Graph.DataAccess.Repositories
{
    public class PostService : IPostService
    {
        private readonly BookStoreDbContext _db;
        public PostService(BookStoreDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Comment> GetCommentsOfPost(Guid PostId) => _db.Posts.Include(x => x.Comments).Where(x => x.Id == PostId).First().Comments.ToList();

        public AppUser GetIssuerOfPost(Guid PostId) => _db.Posts.Include(x => x.User).Where(x => x.Id == PostId).First().User;

        public IEnumerable<Post> GetPosts() {
           var posts = _db.Posts.Include(x => x.Comments).Include(x => x.User).ToList();
            return posts;
        }
    }
}
