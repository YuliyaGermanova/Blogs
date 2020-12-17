using Microsoft.EntityFrameworkCore;
using BlogsApi.Models;

namespace BlogsApi
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Blog> Blog { get; set; }

        public ApplicationContext()
        {
           // Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=DbBlog;Username=postgres;");
        }
    }
}
