using MediatR;

namespace Sample.Application.Queries.GetUserDetails
{
    public class GetUserDetailsQuery : IRequest<UserDetailsResponse>
    {
        public string Username { get; set; }

        public GetUserDetailsQuery(string username)
        {
            Username = username;
        }
    }
}