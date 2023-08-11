using CRUDAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDAPI.Data
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options):base(options)
        {
            
        }


        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
           
        //}

    }
}
