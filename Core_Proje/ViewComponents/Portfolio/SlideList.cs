using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Portfolio
{
    public class SlideList : ViewComponent
    {
        private readonly IPortfolioService _portfolioService;

        public SlideList(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }
        public IViewComponentResult Invoke()
        {
            var values = _portfolioService.TGetList();
            return View(values);
        }
    }
}
