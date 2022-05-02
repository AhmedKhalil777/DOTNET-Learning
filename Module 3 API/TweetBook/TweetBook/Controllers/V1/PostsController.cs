using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TweetBook.Contracts.V1;
using TweetBook.Domain;

namespace TweetBook.Controllers.V1
{
    [ApiController]
    public class PostsController : ControllerBase
    {
        private List<Post> _Posts;
        public PostsController()
        {
            _Posts = new List<Post>();
            for (int i = 0; i < 5; i++)
            {
                _Posts.Add(new Post { Id = Guid.NewGuid().ToString() });
            }
        }
        [HttpGet(ApiRoutes.Posts.GetAll)]
        public IActionResult GetAll() => Ok(_Posts);
        [HttpPost(ApiRoutes.Posts.Create)]
        public IActionResult Create()
        {
            Post post = new Post { Id = Guid.NewGuid().ToString()};
            _Posts.Add(post);
            return Ok(post);
        }
    }
}