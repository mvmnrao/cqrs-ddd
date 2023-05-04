using Microsoft.EntityFrameworkCore;
using Sample.Domain.Users;
using Sample.Infrastructure.Database;

namespace Sample.Infrastructure.Users
{
    public class UsersRepository : IUsersRepository
    {
        private readonly UserDbContext usersContext;

        public UsersRepository(UserDbContext usersContext)
        {
            this.usersContext = usersContext ?? throw new ArgumentNullException($"{nameof(usersContext)} can not be null.");
        }

        public async Task AddAsync(User user)
        {
            await usersContext.Users.AddAsync(user);
            await usersContext.SaveChangesAsync();
        }

        public async Task<User> GetByIdAsync(Guid userId)
        {
            return await usersContext.Users.SingleOrDefaultAsync(user => user.ID == userId);
        }
    }
}