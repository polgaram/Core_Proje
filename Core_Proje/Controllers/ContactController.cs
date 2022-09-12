using BusinessLayer.Abstract;
using DataAccsessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class ContactController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly Context _context;

        public ContactController(IMessageService messageService, Context context)
        {
            _messageService = messageService;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index(string ContactMail)
        {
            ViewBag.v1 = "Mesajlar Listesi";
            ViewBag.v2 = "Mesajlar";
            ViewBag.Url = "/Contact/Index";

            var mesajlar = from x in _context.Messages select x;
            if (!string.IsNullOrEmpty(ContactMail))
            {
                mesajlar=mesajlar.Where(x=>x.Mail.Contains(ContactMail));
            }

            return View(mesajlar.ToList());
        }
        public IActionResult ContactDetails(int id)
        {
            ViewBag.v1 = "Mesajlar Listesi";
            ViewBag.v2 = "Mesajlar";
            ViewBag.Url = "/Contact/Index";
            var values = _messageService.TGetByID(id);

            return View(values);
        }
        public IActionResult DeleteContact(int id)
        {
            var values = _messageService.TGetByID(id);
            _messageService.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}
