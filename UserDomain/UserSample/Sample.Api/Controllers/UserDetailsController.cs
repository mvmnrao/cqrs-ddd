using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Queries.GetUserDetails;

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
        public async Task<IActionResult> GetUserByUsernameAsync([FromQuery] string username, CancellationToken cancellationToken)
        {
            var query = new GetUserDetailsQuery(username);

            return Ok(await sender.Send(query, cancellationToken));
        }
    }
}