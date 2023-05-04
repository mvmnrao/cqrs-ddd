using MediatR;

namespace Sample.Application.Users.Register
{
    public class RegisterUserCommand : IRequest
    {
        public string Username { get; set; }

        public string Email { get; set; }
    }
}