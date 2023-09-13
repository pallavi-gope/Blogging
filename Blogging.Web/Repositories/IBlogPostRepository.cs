using Blogging.Web.Models.Domain;

namespace Blogging.Web.Repositories
{
    public interface IBlogPostRepository
    {
        Task<IEnumerable<BlogPost>> GetAllAsync();
        Task<BlogPost> GetAsync(Guid id);
        Task<BlogPost> GetByUrlHandleAsync(string urlHandle);
        Task<BlogPost> AddAsync(BlogPost post);
        Task<BlogPost> UpdateAsync(BlogPost post);
        Task<BlogPost> DeleteAsync(Guid id);
    }
}
