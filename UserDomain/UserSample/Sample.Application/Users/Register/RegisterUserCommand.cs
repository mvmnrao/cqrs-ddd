using MediatR;

namespace Sample.Application.Users.Register
{
    public class RegisterUserCommand : IRequest<string>
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public RegisterUserCommand(string username, string email)
        {
            Username = username;
            Email = email;
        }
    }
}