using Microsoft.AspNetCore.Identity;

namespace Blogging.Web.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<IdentityUser>> GetAll();
    }
}
