using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.v1 = "Hakkımda Sayfası";
            ViewBag.v2 = "Hakkımda";
            ViewBag.Url = "/About/Index";
            var values = _aboutService.TGetList().FirstOrDefault();
            return View(values);
        }
        [HttpPost]
        public IActionResult Index(About about)
        {
            _aboutService.TUpdate(about);
            return Redirect("/Default/Index#about");
        }
    }
}
