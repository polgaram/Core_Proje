using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.ViewComponents
{
    public class Notification:ViewComponent
    {
        private readonly IAnnouncementService _announcementService;

        public Notification(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _announcementService.TGetList().Take(5).ToList();
            return View(values);
        }
    }
}
