using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Users.GetDetails;

namespace Sample.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserDetailsController : Controller
    {
        private readonly ISender sender;

        public UserDetailsController(ISender sender)
        {
            this.sender = sender ?? throw new ArgumentNullException($"{nameof(sender)} can not be null.");
        }

        [HttpGet]
        public async Task<IActionResult> GetUserByIdAsync([FromQuery] GetUserDetailsQuery userDetailsQuery, CancellationToken cancellationToken)
        {
            return Ok(await sender.Send(userDetailsQuery, cancellationToken));
        }
    }
}