using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public IActionResult Index()
        {
            ViewBag.v1 = "Referans Listesi";
            ViewBag.v2 = "Referanslar";
            ViewBag.Url = "/Testimonial/Index/";
            var values = _testimonialService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddTestimonial()
        {
            ViewBag.v1 = "Referans Ekleme Sayfası";
            ViewBag.v2 = "Referanslar";
            ViewBag.Url = "/Testimonial/Index/";
            return View();
        }
        [HttpPost]
        public IActionResult AddTestimonial(Testimonial testimonial)
        {
            _testimonialService.TAdd(testimonial);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditTestimonial(int id)
        {
            ViewBag.v1 = "Referans Detay Sayfası";
            ViewBag.v2 = "Referans Listesi";
            ViewBag.Url = "/Testimonial/Index/";
            var values = _testimonialService.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditTestimonial(Testimonial testimonial)
        {
            _testimonialService.TUpdate(testimonial);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteTestimonial(int id)
        {
            var values = _testimonialService.TGetByID(id);
            _testimonialService.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}
