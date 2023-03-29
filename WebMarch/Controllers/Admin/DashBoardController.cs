using Microsoft.AspNetCore.Mvc;

namespace WebMarch.Controllers.Admin
{
    [Route("/Admin/DashBoard")]
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Admin/DashBoard/Index.cshtml");
        }
    }
}
