using Blogging.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blogging.Web.Data
{
    public class BlogDBContext : DbContext
    {
        public BlogDBContext(DbContextOptions<BlogDBContext> options) : base(options)
        {
        }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DbSet<BlogPostLike> BlogPostLike {get; set;}
        public DbSet<BlogPostComment> BlogPostComment { get; set; }
    }
}
