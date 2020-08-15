using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MyBrokenPage.Common;
using MyBrokenPage.UI.Constants;

namespace MyBrokenPage.UI.Controllers
{
    [Route(Routes.SecurityController)]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        [HttpPost(Routes.SecurityControllerSqlInjection)]
        public IActionResult SqlInjectionMethod([FromForm][Required] SqlInjectionTestingEnum method)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            ConfigurationManager.SqlInjectionMethod = method;

            return Ok();
        }

        [HttpPost(Routes.SecurityControllerXss)]
        public IActionResult Xss([FromForm][Required] XssTestingEnum method)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            ConfigurationManager.XssMethod = method;

            return Ok();
        }
    }
}
