using Microsoft.AspNetCore.Mvc;

namespace SIGPIP.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult Members()
        {
            return View("Members");
        }
    }
}
