using System.Collections.Generic;
using System.Linq;

namespace BlogsApi.Models
{

    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(p => p.Id == id);
        }

        public void Update(User user) {
             _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
             var currentUser = GetById(id);
            _context.Users.Remove(currentUser);
            _context.SaveChanges();
        }
    }
}