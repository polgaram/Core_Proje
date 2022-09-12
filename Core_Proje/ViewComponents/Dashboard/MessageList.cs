
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class MessageList:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
