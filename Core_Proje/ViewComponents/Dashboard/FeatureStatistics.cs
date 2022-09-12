using BusinessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class FeatureStatistics:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
