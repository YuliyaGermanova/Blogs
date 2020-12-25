using System;
using System.Collections.Generic;
using System.Linq;


namespace BlogsApi.Models
{
    public class BlogRepository : IBlogRepository
    {

        private readonly ApplicationContext _context;

        public BlogRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(Blog blog)
        {
            _context.Blogs.Add(blog);
            _context.SaveChanges();
        }

        public Blog GetById(int id)
        {
            return _context.Blogs.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Blog> GetAll()
        {
            return _context.Blogs.ToList();
        }

        public void Remove(int id)
        {
            var currentBlog = GetById(id);
            _context.Blogs.Remove(currentBlog);
            _context.SaveChanges();
        }

        public void Update(Blog blog)
        {
            _context.Blogs.Update(blog);
            _context.SaveChanges();
        }
    }
}