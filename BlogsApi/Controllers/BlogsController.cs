using System;
using System.Collections.Generic;
using System.Linq;
using BlogsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogsApi.Controllers
{
    [ApiController]
    [Route("api/blogs")]
    public class BlogsController : Controller
    {
        ApplicationContext db;

        public BlogsController(ApplicationContext context)
        {
            db = context;
            if (!db.Blog.Any())
            {
                db.Blog.Add(new Blog
                {
                    UserName = "Login1",
                    ThemaBlogs = "Thema1",
                    TextBlogs = "Какой-то текст",
                    DateCreate = DateTime.Now
                });
                db.SaveChanges();
            }
        }
        [HttpGet]
        public IEnumerable<Blog> Get()
        {
            return db.Blog.ToList();
        }

        [HttpGet("{id}")]
        public Blog Get(int id)
        {
            Blog blog = db.Blog.FirstOrDefault(x => x.Id == id);
            return blog;
        }

        [HttpPost]
        public IActionResult Post(Blog blog)
        {
            if (ModelState.IsValid)
            {
                db.Blog.Add(blog);
                db.SaveChanges();
                return Ok(blog);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public IActionResult Put(Blog blog)
        {
            if (ModelState.IsValid)
            {
                db.Update(blog);
                db.SaveChanges();
                return Ok(blog);
            }
            return BadRequest(ModelState);
        }

         [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Blog blog = db.Blog.FirstOrDefault(x => x.Id == id);
            if (blog != null)
            {
                db.Blog.Remove(blog);
                db.SaveChanges();
            }
            return Ok(blog);
        }

    }
}
