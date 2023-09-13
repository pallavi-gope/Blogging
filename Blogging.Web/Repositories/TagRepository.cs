using Blogging.Web.Data;
using Blogging.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blogging.Web.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly BlogDBContext blogDBContext;

        public TagRepository(BlogDBContext blogDBContext)
        {
            this.blogDBContext = blogDBContext;
        }
        public async Task<Tag> AddAsync(Tag tag)
        {
            await blogDBContext.Tags.AddAsync(tag);
            await blogDBContext.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag?> DeleteAsync(Guid id)
        {
            var tag = await blogDBContext.Tags.FindAsync(id);
            if (tag != null)
            {
                blogDBContext.Tags.Remove(tag);
                await blogDBContext.SaveChangesAsync();
                return tag;
            }
            return null;
        }

        public async Task<IEnumerable<Tag?>> GetAllAsync()
        {
            // use db context to retrieve data from database
            return await blogDBContext.Tags.ToListAsync();
        }

        public async Task<Tag?> GetAsync(Guid id)
        {
            var tag = await blogDBContext.Tags.FirstOrDefaultAsync(x => x.Id == id);
            return tag;

        }

        public async Task<Tag?> UpdateAsync(Tag tag)
        {
            var existingTag = await blogDBContext.Tags.FindAsync(tag.Id);
            if(existingTag != null)
            {
                existingTag.Name = tag.Name;
                existingTag.DisplayName = tag.DisplayName;
            }
            await blogDBContext.SaveChangesAsync();
            return existingTag;
        }
    }
}
