using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hubtel.eCommerce.Cart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthTestController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult GetName()
        {
            var response = new
            {
                name = "Isaac",
                password = "4526"
            };
            return Ok(response);
        }
    }
}
