using FluentValidation;
using Sample.Api.Controllers.Users.Requests;

namespace Sample.Api.Controllers.Users.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserRequest>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username can not be empty.");
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Email should be in valid format.");
        }
    }
}