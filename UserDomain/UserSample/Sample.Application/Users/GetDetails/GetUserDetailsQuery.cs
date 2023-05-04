using MediatR;

namespace Sample.Application.Users.GetDetails
{
    public class GetUserDetailsQuery : IRequest<UserDetailsDto>
    {
        public Guid UserId { get; set; }
    }
}