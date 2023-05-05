using Sample.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Sample.Domain.Users;
using Sample.Infrastructure.Users;
using Sample.Application.Users.GetDetails;
using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace Sample.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            //services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(typeof(GetUserDetailsQuery).Assembly));
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddFluentValidationAutoValidation();//.AddFluentValidationClientsideAdapters();
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehaviour<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            //services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));

            return services;
        }

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<UserDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Sample.Application")));// typeof(UserDbContext).Assembly.FullName)));
            
            using UserDbContext? context = services.BuildServiceProvider().GetService<UserDbContext>();
            if (context != null)
                UserDbContextSeed.SeedAsync(context).Wait();

            services.AddScoped<IUsersRepository, UsersRepository>();
            //services.AddScoped<IDomainEventService, DomainEventService>();

            return services;
        }
    }
}