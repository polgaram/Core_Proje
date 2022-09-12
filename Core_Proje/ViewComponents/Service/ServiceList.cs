using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Service
{
    public class ServiceList : ViewComponent
    {
        private readonly IServiceService _serviceService;

        public ServiceList(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        public IViewComponentResult Invoke()
        {
            var values = _serviceService.TGetList();
            return View(values);
        }
    }
}
