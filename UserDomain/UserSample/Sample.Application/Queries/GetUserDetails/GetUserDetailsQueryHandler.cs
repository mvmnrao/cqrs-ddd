using MediatR;
using Sample.Domain.Users;
using Sample.Infrastructure.Repositories.Interfaces;

namespace Sample.Application.Queries.GetUserDetails
{
    internal sealed class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDetailsResponse>
    {
        private readonly IUsersRepository usersRepository;

        public GetUserDetailsQueryHandler(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository ?? throw new ArgumentNullException($"{nameof(usersRepository)} can not be null.");
        }

        public async Task<UserDetailsResponse> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var user = await usersRepository.GetByUsernameAsync(request.Username);
            return new UserDetailsResponse
            {
                Id = user.ID,
                Email = user.Email
            };
        }
    }
}