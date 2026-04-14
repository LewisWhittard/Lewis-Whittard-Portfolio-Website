using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMWDev.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CookieController : ControllerBase
    {
        [HttpPost("set")]
        public IActionResult Set([FromBody] bool value)
        {
            HttpContext.Session.SetString("CookieApproved", value.ToString().ToLower());
            return Ok(value);
        }
    }
}
