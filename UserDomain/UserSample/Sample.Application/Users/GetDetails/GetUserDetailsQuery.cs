using MediatR;

namespace Sample.Application.Users.GetDetails
{
    public class GetUserDetailsQuery : IRequest<UserDetailsModel>
    {
        public string Username { get; set; }

        public GetUserDetailsQuery(string username)
        {
            Username = username;
        }
    }
}