using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAppUserLogin.Controllers
{
    [Authorize]
    public class PanelController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Username = User.Identity?.Name;
            return View();
        }
    }
}
