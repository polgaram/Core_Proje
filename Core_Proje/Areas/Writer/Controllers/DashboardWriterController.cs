using DataAccsessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/{controller}/{action}/{id?}")]
    public class DashboardWriterController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;
        private readonly Context _context;

        public DashboardWriterController(UserManager<WriterUser> userManager, Context context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            WriterUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Name = $"{user.Name} {user.SurName}";


            //Weather API
            string appid = "e4600fdc8988f09d5d1e0389af781027";
            string connectionIstanbul = $"https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid={appid}";
            string connectionKocaeli = $"https://api.openweathermap.org/data/2.5/weather?q=kocaeli&mode=xml&lang=tr&units=metric&appid={appid}";
            XDocument document = XDocument.Load(connectionIstanbul);
            XDocument document2 = XDocument.Load(connectionKocaeli);
            ViewBag.WeatherIstanbul = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            ViewBag.WeatherKocaeli = document2.Descendants("temperature").ElementAt(0).Attribute("value").Value;

            ViewBag.GelenMesajSayisi = _context.WriterMessages.Where(x=>x.Receiver==user.Email).Count();
            ViewBag.DuyuruSayisi = _context.Announcements.Count();
            ViewBag.ToplamKullaniciSayisi = _context.Users.Count();
            ViewBag.ToplamYetenekSayisi = _context.Skills.Count();

            return View();
        }
    }
}
//https://api.openweathermap.org/data/2.5/weather?q=istanbul&mode=xml&lang=tr&units=metric&appid=e4600fdc8988f09d5d1e0389af781027