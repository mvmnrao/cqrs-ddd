using Sample.Domain.Users;

namespace Sample.Infrastructure.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        Task<string> AddAsync(User user);

        Task<User> GetByUsernameAsync(string username);
    }
}