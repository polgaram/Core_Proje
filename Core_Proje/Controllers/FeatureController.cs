using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class FeatureController : Controller
    {
        private readonly IFeatureService _featureService;

        public FeatureController(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.v1 = "Öne Çıkan Sayfası";
            ViewBag.v2 = "Öne Çıkanlar";
            ViewBag.Url = "/Feature/Index";
            var values = _featureService.TGetList().FirstOrDefault();
            return View(values);
        }
        [HttpPost]
        public IActionResult Index(Feature feature)
        {
            _featureService.TUpdate(feature);
            return RedirectToAction("Index","Default");
        }
    }
}
