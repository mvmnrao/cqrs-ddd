namespace Sample.Domain.Users
{
    public interface IUsersRepository
    {
        Task AddAsync(User user);

        Task<User> GetByIdAsync(Guid userId);
    }
}