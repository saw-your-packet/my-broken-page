using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MyBrokenPage.Common.SQLi;
using MyBrokenPage.UI.Constants;

namespace MyBrokenPage.UI.Controllers
{
    [Route(Routes.SecurityController)]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        [HttpPost(Routes.SecurityControllerSqlInjection)]
        public IActionResult SqlInjectionMethod([FromForm][Required] SqlInjectionTestingEnum testingMethod)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            DatabaseConfigurations.SelectedSqlInjectionMethod = testingMethod;

            return Ok();
        }
    }
}
