using Microsoft.EntityFrameworkCore;
using BlogsApi.Models;

namespace BlogsApi
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostType> PostTypes { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            // Database.EnsureCreated();

            // PostTypes.Add(new PostType {
            //     Name = "Кулинария"
            // });
            // PostTypes.Add(new PostType {
            //     Name = "Спорт"
            // });
            // PostTypes.Add(new PostType {
            //     Name = "Природа"
            // });

            // User user = new User {
            //     Login = "Редактор"
            // };
            // user.setPassHash("827ccb0eea8a706c4c34a16891f84e7b");

            // Users.Add(user);

            // SaveChanges();

            
        }
    }
}
