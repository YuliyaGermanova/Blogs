using System;
using System.Collections.Generic;
using BlogsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogsApi.Controllers
{

    [ApiController]
    [Route("api/blogs/postType")]
    public class PostsTypesController : Controller
    {
        private IPostTypeRepository _postTypes { get; set; }

        public PostsTypesController(IPostTypeRepository postsType)
        {
            _postTypes = postsType;
            
        }
        [HttpGet]
        public IEnumerable<PostType> Get()
        {
           return _postTypes.GetAll();
        }

        [HttpGet("{id}")]
        public PostType Get(int id)
        {
            return _postTypes.GetById(id);
        }

        [HttpPost]
        public IActionResult Post(PostType type)
        {
             _postTypes.Add(type);
             return Ok(type);
        }

         [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var postType = _postTypes.GetById(id);
            _postTypes.Remove(id);
            return Ok(postType);
        }

    }
}
