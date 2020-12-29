using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


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
            _context.Posts.Update(post);
            _context.SaveChanges();
        }

        public Post GetById(int id)
        {
            Post post = _context.Posts.FirstOrDefault(p => p.Id == id);
            return post;
        }

        public IEnumerable<Post> GetAll()
        {
            List<Post> list = _context.Posts
                .Include(post => post.PostType)
                .Include(post => post.User)
                .ToList();

            return list;
        }

        public void Remove(int id)
        {
            var currentPost = GetById(id);
            _context.Posts.Remove(currentPost);
            _context.SaveChanges();
        }

        public Post Update(int id, Post post)
        {
            Post foundedPost = GetById(id);

            if (foundedPost is null) return null;

            foundedPost.PostContent = post.PostContent;
            foundedPost.PostType = post.PostType;
            foundedPost.User = post.User;

            _context.Posts.Update(foundedPost);
            _context.SaveChanges();

            return foundedPost;
        }
    }
}