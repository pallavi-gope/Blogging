using Blogging.Web.Models.Domain;

namespace Blogging.Web.Repositories
{
    public interface IBlogPostLikeRepository
    {
        Task<int> GetTotalLikes(Guid blogPostId);
        Task<BlogPostLike> AddLikeForBlog(BlogPostLike blogPostLike);
        Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId);
    }
}
