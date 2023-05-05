using MediatR;
using Sample.Domain.Users;

namespace Sample.Application.Users.Register
{
    internal sealed class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, string>
    {
        private readonly IUsersRepository usersRepository;

        public RegisterUserCommandHandler(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository ?? throw new ArgumentNullException($"{nameof(usersRepository)} can not be null.");
        }

        public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var username = await usersRepository.AddAsync(new User
            {
                ID = Guid.NewGuid(),
                Email = request.Email,
                Username = request.Username
            });

            return username;
        }
    }
}