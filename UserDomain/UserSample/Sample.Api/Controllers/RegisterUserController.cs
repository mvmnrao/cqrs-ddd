using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Users.Register;

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

        public async Task<IActionResult> RegisterUser(RegisterUserCommand registerUserCommand, CancellationToken cancellationToken)
        {
            await mediator.Send(registerUserCommand, cancellationToken);
            return Ok();
        }
    }
}