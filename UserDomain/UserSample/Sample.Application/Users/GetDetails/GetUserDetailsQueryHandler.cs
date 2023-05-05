using MediatR;
using Sample.Domain.Users;

namespace Sample.Application.Users.GetDetails
{
    internal sealed class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDetailsModel>
    {
        private readonly IUsersRepository usersRepository;

        public GetUserDetailsQueryHandler(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository ?? throw new ArgumentNullException($"{nameof(usersRepository)} can not be null.");
        }

        public async Task<UserDetailsModel> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var user = await usersRepository.GetByUsernameAsync(request.Username);
            return new UserDetailsModel
            {
                Id = user.ID,
                Email = user.Email
            };
        }
    }
}