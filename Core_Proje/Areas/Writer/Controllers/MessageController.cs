using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccsessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    //[Route("Writer/Message")]
    [Route("Writer/{controller}/{action}/{id?}")]
    [Authorize]
    public class MessageController : Controller
    {
        private readonly IWriterMessageService _writerMessageService;
        private readonly UserManager<WriterUser> _userManager;
        private readonly Context _context;

        public MessageController(IWriterMessageService writerMessageService, UserManager<WriterUser> userManager, Context context)
        {
            _writerMessageService = writerMessageService;
            _userManager = userManager;
            _context = context;
        }
        //[Route("")]
        //[Route("ReceiverMessages")]
        public async Task<IActionResult> ReceiverMessages(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList=_writerMessageService.GetListReceiverMessage(p);
            return View(messageList);
        }
        //[Route("")]
        //[Route("SenderMessages")]
        public async Task<IActionResult> SenderMessages(string p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            p = values.Email;
            var messageList = _writerMessageService.GetListSenderMessage(p);
            return View(messageList);
        }
        //[Route("ReceiverMessageDetails/{id}")]
        public IActionResult ReceiverMessageDetails(int id)
        {
            WriterMessage writerMessage = _writerMessageService.TGetByID(id);
            return View(writerMessage);
        }
        //[Route("SenderMessageDetails/{id}")]
        public IActionResult SenderMessageDetails(int id)
        {
            WriterMessage writerMessage = _writerMessageService.TGetByID(id);
            return View(writerMessage);
        }
        //[Route("")]
        //[Route("SendMessage")]
        [HttpGet]
        public async Task<IActionResult> SendMessage()
        {
            return View();
        }
        //[Route("")]
        //[Route("SendMessage")]
        [HttpPost]
        public async Task<IActionResult> SendMessage(WriterMessage p)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            string mail = values.Email;
            string name = $"{values.Name} {values.SurName}";
            p.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            p.Sender=mail;
            p.SenderName=name;
            var usernamesurname= _context.Users.Where(x=>x.Email==p.Receiver).Select(y=>y.Name+" "+ y.SurName).FirstOrDefault();
            p.ReceiverName = usernamesurname;
            _writerMessageService.TAdd(p);
            return RedirectToAction("SenderMessages");
        }
    }
}
