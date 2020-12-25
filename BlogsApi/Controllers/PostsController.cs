using System;
using System.Collections.Generic;
using System.Linq;
using BlogsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogsApi.Controllers
{

    [ApiController]
    [Route("api/blog/post")]
    public class PostsController : Controller
    {
        private IPostRepository _posts { get; set; }

        public PostsController(IPostRepository posts)
        {
            _posts = posts;   
        }
        [HttpGet]
        public IEnumerable<Post> Get()
        {
           return _posts.GetAll();
        }

        [HttpGet("{id}")]
        public Post Get(int id)
        {
            return _posts.GetById(id);
        }

        [HttpPost]
        public IActionResult Post(Post post)
        {
             _posts.Add(post);
             return Ok(post);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Post post)
        {
            Post foundedPost = _posts.GetById(id);
            foundedPost.PostContent = post.PostContent;
             _posts.Update(foundedPost);
            return Ok(post);
        }

         [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var post = _posts.GetById(id);
            _posts.Remove(id);
            return Ok(post);
        }

    }
}
