using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            ViewBag.v1 = "Hizmet Listesi";
            ViewBag.v2 = "Hizmetler";
            ViewBag.Url = "/Service/Index";
            var values = _serviceService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddService()
        {
            ViewBag.v1 = "Hizmet Ekleme";
            ViewBag.v2 = "Hizmetler";
            ViewBag.Url = "/Service/Index";
            return View();
        }
        [HttpPost]
        public IActionResult AddService(Service service)
        {
            _serviceService.TAdd(service);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteService(int id)
        {
            var values = _serviceService.TGetByID(id);
            _serviceService.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditService(int id)
        {
            ViewBag.v1 = "Hizmet Güncelleme";
            ViewBag.v2 = "Hizmetler";
            ViewBag.Url = "/Service/Index";
            var values = _serviceService.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditService(Service service)
        {
            _serviceService.TUpdate(service);
            return RedirectToAction("Index");
        }
    }
}
