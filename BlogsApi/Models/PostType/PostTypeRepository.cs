using System.Collections.Generic;
using System.Linq;

namespace BlogsApi.Models
{

    public class PostTypeRepository : IPostTypeRepository
    {
        private readonly ApplicationContext _context;
        public PostTypeRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(PostType postType)
        {
            _context.PostTypes.Add(postType);
            _context.SaveChanges();
        }

        public IEnumerable<PostType> GetAll()
        {
            var types = _context.PostTypes.ToList();
            return types;
        }

        public PostType GetById(int id)
        {
            return _context.PostTypes.FirstOrDefault(p => p.Id == id);
        }

        public void Remove(int id)
        {
             var currentPostType = GetById(id);
            _context.PostTypes.Remove(currentPostType);
            _context.SaveChanges();
        }
    }

}