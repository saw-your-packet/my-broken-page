using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBrokenPage.UI.Constants;

namespace MyBrokenPage.UI.Controllers
{
    [Authorize(Roles = ApplicationRoles.Admin)]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}