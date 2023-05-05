using Sample.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Sample.Domain.Users;
using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Sample.Infrastructure.Repositories.Interfaces;
using Sample.Infrastructure.Repositories.Implementations;
using Sample.Application.Queries.GetUserDetails;

namespace Sample.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(GetUserDetailsQuery).Assembly));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddFluentValidationAutoValidation();

            return services;
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Sample.Application")));

            //using UserDbContext? context = services.BuildServiceProvider().GetService<UserDbContext>();
            //if (context != null)
            //    UserDbContextSeed.SeedAsync(context).Wait();

            services.AddScoped<IUsersRepository, UsersRepository>();

            return services;
        }
    }
}