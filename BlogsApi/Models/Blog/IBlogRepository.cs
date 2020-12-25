using System.Collections.Generic;

namespace BlogsApi.Models
{
    public interface IBlogRepository
    {
        void Add(Blog blog);
        IEnumerable<Blog> GetAll();
        Blog GetById(int id);
        void Update(Blog blog);

        void Remove(int id);
    }
}