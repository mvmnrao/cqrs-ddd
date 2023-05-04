using Sample.Domain.Users;

namespace Sample.Infrastructure.Database
{
    public static class UserDbContextSeed
    {
        public static async Task SeedAsync(UserDbContext usersDbContext)
        {
            if (!usersDbContext.Users.Any())
            {
                usersDbContext.Users.Add(new User { ID = Guid.NewGuid(), Username = "Manik", Email = "manik@email.com" });
                usersDbContext.Users.Add(new User { ID = Guid.NewGuid(), Username = "Lalitha", Email = "lalitha@email.com" });
                await usersDbContext.SaveChangesAsync();
            }
        }
    }
}