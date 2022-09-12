using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class DashboardController : Controller
    {

        public IActionResult Index()
        {
            ViewBag.v1 = "Pano Sayfası";
            ViewBag.v2 = "Panolar";
            ViewBag.Url = "/Dashboard/Index/";
            return View();
        }
    }
}
