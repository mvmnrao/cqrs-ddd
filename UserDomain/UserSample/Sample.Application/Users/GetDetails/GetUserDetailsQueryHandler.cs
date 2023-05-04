using MediatR;
using Sample.Domain.Users;

namespace Sample.Application.Users.GetDetails
{
    internal sealed class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDetailsDto>
    {
        private readonly IUsersRepository usersRepository;

        public GetUserDetailsQueryHandler(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository ?? throw new ArgumentNullException($"{nameof(usersRepository)} can not be null.");
        }

        public async Task<UserDetailsDto> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var user = await usersRepository.GetByIdAsync(request.UserId);
            return new UserDetailsDto
            {
                Id = user.ID,
                Email = user.Email
            };
        }
    }
}
