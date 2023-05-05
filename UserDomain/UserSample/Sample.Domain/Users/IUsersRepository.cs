namespace Sample.Domain.Users
{
    public interface IUsersRepository
    {
        Task<string> AddAsync(User user);

        Task<User> GetByUsernameAsync(string username);
    }
}