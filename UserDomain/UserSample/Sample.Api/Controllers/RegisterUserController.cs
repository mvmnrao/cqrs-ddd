using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.Api.Requests;
using Sample.Application.Commands.RegisterUser;

namespace Sample.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class RegisterUserController : Controller
    {
        private readonly IMediator mediator;

        public RegisterUserController(IMediator mediator)
        {
            this.mediator = mediator ?? throw new ArgumentNullException($"{nameof(mediator)} can not be null.");
        }

        [HttpPost]

        public async Task<IActionResult> RegisterUser(RegisterUserRequest registerUserRequest, CancellationToken cancellationToken)
        {
            var command = new RegisterUserCommand(registerUserRequest.Username, registerUserRequest.Email);
            return Ok(await mediator.Send(command, cancellationToken));
        }
    }
}