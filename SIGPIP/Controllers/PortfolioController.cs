using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SIGPIP.Controllers
{
    public class PortfolioController : Controller
    {
        public ActionResult ViewPortfolio()
        {
            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }
    }
}
