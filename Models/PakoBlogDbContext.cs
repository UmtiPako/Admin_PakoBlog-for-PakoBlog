using Microsoft.EntityFrameworkCore;

namespace Admin_PakoBlog.Models
{
    public class PakoBlogDbContext : DbContext
    {
        public PakoBlogDbContext(DbContextOptions<PakoBlogDbContext> options) 
            : base(options)
        {

        }

        public DbSet<Author> Author { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
