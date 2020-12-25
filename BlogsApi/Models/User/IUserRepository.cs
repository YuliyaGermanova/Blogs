using System.Collections.Generic;

namespace BlogsApi.Models
{
    public interface IUserRepository
    {
        void Add(User user);
        IEnumerable<User> GetAll();
        User GetById(int id);
        void Update(User user);
        void Remove(int id);
    }
}