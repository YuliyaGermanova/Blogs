using System;
using System.Collections.Generic;
using System.Linq;


namespace BlogsApi.Models
{
    public class PostRepository : IPostRepository
    {

        private readonly ApplicationContext _context;

        public PostRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public Post GetById(int id)
        {
            return _context.Posts.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _context.Posts.ToList();
        }

        public void Remove(int id)
        {
            var currentPost = GetById(id);
            _context.Posts.Remove(currentPost);
            _context.SaveChanges();
        }

        public void Update(Post post)
        {
            _context.Posts.Update(post);
            _context.SaveChanges();
        }
    }
}