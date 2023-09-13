using Blogging.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Blogging.Web.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthDbContext authDbContext;

        public UserRepository(AuthDbContext authDbContext)
        {
            this.authDbContext = authDbContext;
        }
        public async Task<IEnumerable<IdentityUser>> GetAllAsync()
        {
            var users = await authDbContext.Users.ToListAsync();
            return users;
        }
    }
}
