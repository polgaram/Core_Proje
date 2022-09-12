using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/{controller}/{action}/{id?}")]
    public class DefaultController : Controller
    {
        //AnnouncementManager announcementManager = new AnnouncementManager(new EfAnnouncementDal());
        private readonly IAnnouncementService _announcementService;
        private readonly Context _context;

        public DefaultController(IAnnouncementService announcementService, Context context)
        {
            _announcementService = announcementService;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index(string AnnouncementTitle, string AnnouncementStatus, string AnnouncementDate,int AnnouncementId)
        {
            var duyurular = from x in _context.Announcements select x;
            if (!string.IsNullOrEmpty(AnnouncementTitle))
            {
                duyurular = duyurular.Where(x => x.Title.Contains(AnnouncementTitle));
            }
            if (!string.IsNullOrEmpty(AnnouncementDate))
            {
                duyurular = duyurular.Where(x => x.Date >= Convert.ToDateTime(AnnouncementDate));
            }
            if (!string.IsNullOrEmpty(AnnouncementStatus))
            {
                duyurular = duyurular.Where(x => x.Status.Contains(AnnouncementStatus));
            }
            return View(duyurular.ToList());


            //var values = _announcementService.TGetList();
            //return View(values);
        }
        public IActionResult AnnouncementDetails(int id)
        {
            Announcement announcement = _announcementService.TGetByID(id);
            return View(announcement);
        }
    }
}
