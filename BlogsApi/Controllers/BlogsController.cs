using System.Collections.Generic;
using BlogsApi.Models;
using Microsoft.AspNetCore.Mvc;
namespace BlogsApi.Controllers
{

    [ApiController]
    [Route("api/blog")]
    public class BlogsController : Controller
    {
        private IBlogRepository _blog { get; set; }

        public BlogsController(IBlogRepository blog)
        {
            _blog = blog; 
        }
        [HttpGet]
        public IEnumerable<Blog> Get()
        {
           return _blog.GetAll();
        }

        [HttpGet("{id}")]
        public Blog Get(int id)
        {
            return _blog.GetById(id);
        }

        [HttpPost]
        public IActionResult Post(Blog blog)
        {
             _blog.Add(blog);
             return Ok(blog);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Blog blog)
        {
            Blog foundedBlog = _blog.GetById(id);
             _blog.Update(foundedBlog);
            return Ok(foundedBlog);
        }

         [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var post = _blog.GetById(id);
            _blog.Remove(id);
            return Ok(post);
        }

    }
}
