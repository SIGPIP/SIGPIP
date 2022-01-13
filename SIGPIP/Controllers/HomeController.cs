using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SIGPIP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Team()
        {
            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }
    }
}
