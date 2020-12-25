using System.Collections.Generic;

namespace BlogsApi.Models
{
    public interface IPostRepository
    {
        void Add(Post post);
        IEnumerable<Post> GetAll();
        Post GetById(int id);
        void Remove(int id);
        void Update(Post post); 
    }
}