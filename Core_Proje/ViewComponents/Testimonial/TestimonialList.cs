using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Testimonial
{
    public class TestimonialList:ViewComponent
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialList(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public IViewComponentResult Invoke()
        {
            var values= _testimonialService.TGetList();
            return View(values);
        }
    }
}
