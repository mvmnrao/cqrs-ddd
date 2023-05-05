using FluentValidation;
using Sample.Api.Requests;

namespace Sample.Api.Validators
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserRequest>
    {
        public RegisterUserValidator()
        {
            RuleFor(registerUserRequest => registerUserRequest.Username).NotEmpty().WithMessage("Username is required.");
            RuleFor(registerUserRequest => registerUserRequest.Email)
                .NotEmpty().WithMessage("Email address is required.")
                .Matches(@"^\S+@\S+\.\S+$")
                .WithMessage("Email address should be in valid format.");
        }
    }
}