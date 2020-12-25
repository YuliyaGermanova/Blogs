using System.Collections.Generic;

namespace BlogsApi.Models
{

    public interface IPostTypeRepository
    {
        void Add(PostType postType);
        IEnumerable<PostType> GetAll();
        PostType GetById(int id);
        void Remove(int id);
    }

}