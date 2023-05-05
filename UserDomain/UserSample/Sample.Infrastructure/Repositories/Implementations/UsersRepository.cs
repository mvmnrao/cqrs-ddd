using Microsoft.EntityFrameworkCore;
using Sample.Common.Exceptions;
using Sample.Domain.Users;
using Sample.Infrastructure.Database;
using Sample.Infrastructure.Repositories.Interfaces;

namespace Sample.Infrastructure.Repositories.Implementations
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext usersContext;

        public UsersRepository(ApplicationDbContext usersContext)
        {
            this.usersContext = usersContext ?? throw new ArgumentNullException($"{nameof(usersContext)} can not be null.");
        }

        public async Task<string> AddAsync(User user)
        {
            var existingUser = await usersContext.Users.SingleOrDefaultAsync(u => u.Username == user.Username);

            if (existingUser != null)
                throw new ExistingUserException($"User with username {user.Username} already exists.");

            await usersContext.Users.AddAsync(user);
            await usersContext.SaveChangesAsync();

            return user.Username;
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            var user = await usersContext.Users.SingleOrDefaultAsync(user => user.Username == username);
            return user ?? throw new UserNotFoundException($"User with username {username} not found.");
        }
    }
}