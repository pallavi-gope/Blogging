using Blogging.Web.Data;
using Blogging.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blogging.Web.Repositories
{
    public class BlogPostCommentRepository : IBlogPostCommentRepository
    {
        private readonly BlogDBContext blogDBContext;

        public BlogPostCommentRepository(BlogDBContext blogDBContext)
        {
            this.blogDBContext = blogDBContext;
        }
        public async Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment)
        {
            await blogDBContext.BlogPostComment.AddAsync(blogPostComment);    
            await blogDBContext.SaveChangesAsync();
            return blogPostComment;
        }

        public async Task<IEnumerable<BlogPostComment>> GetCommentsByBlogIdAsync(Guid blogPostId)
        {
            return await blogDBContext.BlogPostComment.Where(x => x.BlogPostId == blogPostId)
                  .ToListAsync();
        }
    }
}
