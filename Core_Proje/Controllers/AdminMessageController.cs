using BusinessLayer.Abstract;
using DataAccsessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    [Authorize(Roles ="Admin")]
    [Route("{controller}/{action}/{id?}")]
    public class AdminMessageController : Controller
    {
        private readonly IWriterMessageService _writerMessageService;
        private readonly UserManager<WriterUser> _userManager;
        private readonly Context _context;

        public AdminMessageController(IWriterMessageService writerMessageService, UserManager<WriterUser> userManager, Context context)
        {
            _writerMessageService = writerMessageService;
            _userManager = userManager;
            _context = context;
        }

        public IActionResult ReceiverMessageList()
        {
            ViewBag.v1 = "Gelen Mesajlar Kutusu";
            ViewBag.v2 = "Mesajlar";
            ViewBag.Url = "/AdminMessage/ReceiverMessageList";
            var values = _writerMessageService.GetListReceiverMessage("bozalp@turpak.com.tr");
            return View(values);
        }
        public IActionResult SenderMessageList()
        {
            ViewBag.v1 = "Giden Mesajlar Kutusu";
            ViewBag.v2 = "Mesajlar";
            ViewBag.Url = "/AdminMessage/SenderMessageList";
            var values = _writerMessageService.GetListSenderMessage("bozalp@turpak.com.tr");
            return View(values);
        }
        public IActionResult ReceiverMessageDetails(int id)
        {
            ViewBag.v1 = "Gelen Mesaj Detayları";
            ViewBag.v2 = "Gelen Mesajlar Kutusu";
            ViewBag.Url = "/AdminMessage/ReceiverMessageList";
            WriterMessage writerMessage = _writerMessageService.TGetByID(id);
            return View(writerMessage);
        }
        public IActionResult SenderMessageDetails(int id)
        {
            ViewBag.v1 = "Gönderilen Mesaj Detayları";
            ViewBag.v2 = "Giden Mesajlar Kutusu";
            ViewBag.Url = "/AdminMessage/SenderMessageList";
            WriterMessage writerMessage = _writerMessageService.TGetByID(id);
            return View(writerMessage);
        }
        [HttpGet]
        public async Task<IActionResult> SendMessage()
        {
            ViewBag.v1 = "Yeni Mesaj Oluşturma Sayfası";
            ViewBag.v2 = "Mesajlar";
            ViewBag.Url = "/AdminMessage/SenderMessageList";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(WriterMessage p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            string name = $"{values.Name} {values.SurName}";
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.Sender = mail;
            p.SenderName = name;
            var usernamesurname = _context.Users.Where(x => x.Email == p.Receiver).Select(y => y.Name + " " + y.SurName).FirstOrDefault();
            p.ReceiverName = usernamesurname;
            _writerMessageService.TAdd(p);
            return RedirectToAction("SenderMessageList");
        }
    }
}
