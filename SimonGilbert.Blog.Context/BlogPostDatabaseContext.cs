using Microsoft.EntityFrameworkCore;
using SimonGilbert.Blog.Models;

namespace SimonGilbert.Blog.Context
{
    public class BlogPostDatabaseContext : DbContext
    {
        public BlogPostDatabaseContext(
            DbContextOptions<BlogPostDatabaseContext> dbContextOptions) 
            : base(dbContextOptions) { }

        public DbSet<BlogPost> BlogPosts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>()
                .HasKey(x => x.Id);
        }
    }
}
