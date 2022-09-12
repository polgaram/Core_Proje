using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class ContactSubPlaceController : Controller
    {
        private readonly IContactService _contactService;

        public ContactSubPlaceController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.v1 = "Alt İletişim Bilgileri Düzenleme Sayfası";
            ViewBag.v2 = "Alt İletişim Bilgileri";
            ViewBag.Url = "/ContactSubPlace/Index";
            var values = _contactService.TGetList().FirstOrDefault();
            return View(values);
        }
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            _contactService.TUpdate(contact);
            return Redirect("/Default/Index#contact");
        }
    }
}
