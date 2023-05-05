using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Users.GetDetails;

namespace Sample.Api.Controllers.Users
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
        public async Task<IActionResult> GetUserByIdAsync([FromQuery] string username, CancellationToken cancellationToken)
        {
            var query = new GetUserDetailsQuery(username);

            return Ok(await sender.Send(query, cancellationToken));
        }
    }
}