using Blogging.Web.Data;
using Blogging.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blogging.Web.Repositories
{
    public class BlogPostLikeRepository : IBlogPostLikeRepository
    {
        private readonly BlogDBContext blogDBContext;

        public BlogPostLikeRepository(BlogDBContext blogDBContext)
        {
            this.blogDBContext = blogDBContext;
        }

        public async Task<BlogPostLike> AddLikeForBlog(BlogPostLike blogPostLike)
        {
            await blogDBContext.BlogPostLike.AddAsync(blogPostLike);
            await blogDBContext.SaveChangesAsync();
            return blogPostLike;
        }

        public async Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId)
        {
            return await blogDBContext.BlogPostLike.Where(x => x.BlogPostId == blogPostId).ToListAsync();
        }

        public async Task<int> GetTotalLikes(Guid blogPostId)
        {
           return await blogDBContext.BlogPostLike.CountAsync(x => x.BlogPostId == blogPostId);
        }
    }
}
