using MediatR;
using Sample.Domain.Users;

namespace Sample.Application.Users.Register
{
    internal sealed class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand>
    {
        private readonly IUsersRepository usersRepository;

        public RegisterUserCommandHandler(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository ?? throw new ArgumentNullException($"{nameof(usersRepository)} can not be null.");
        }

        public async Task Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            await usersRepository.AddAsync(new User
            {
                ID = Guid.NewGuid(),
                Email = request.Email,
                Username = request.Username
            });
        }
    }
}