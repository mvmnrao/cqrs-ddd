using Sample.Api.Requests;
using Sample.Api.Validators;

namespace Sample.Api.Tests
{
    public class RegisterUserValidatorTests
    {
        private RegisterUserValidator validator;

        public RegisterUserValidatorTests()
        {
            validator = new RegisterUserValidator();
        }

        [Fact]
        public void ValidEmailFormat()
        {
            var command = new RegisterUserRequest
            {
                Username = "test",
                Email = "test@test.com"
            };

            var result = validator.Validate(command);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void InvalidEmailFormat()
        {
            var command = new RegisterUserRequest
            {
                Username = "test",
                Email = "test@test"
            };

            var result = validator.Validate(command);

            Assert.False(result.IsValid);
        }

        [Fact]
        public void UsernameEmpty()
        {
            var command = new RegisterUserRequest
            {
                Username = "",
                Email = "test@test.com"
            };

            var result = validator.Validate(command);

            Assert.False(result.IsValid);
        }
    }
}