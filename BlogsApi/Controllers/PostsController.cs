using System;
using System.Collections.Generic;
using System.Linq;
using BlogsApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace BlogsApi.Controllers
{

    [ApiController]
    [Produces("application/json")]
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
        public IActionResult Get(int id)
        {
            Post foundedPost = _posts.GetById(id);

            if (foundedPost is null) return NotFound(id);

            return Ok(foundedPost);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Post post)
        {
             _posts.Add(post);
             return Ok(post);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Post post)
        {
            Post updated = _posts.Update(id, post);
            if (updated is null) return NotFound(id);

            return Ok(updated);
        }

         [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var post = _posts.GetById(id);

            if (post is null) return NotFound(id);

            _posts.Remove(post.Id);

            return Ok(post);
        }

    }
}
