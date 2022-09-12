using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public IActionResult Index()
        {
            ViewBag.v1 = "Proje Listesi";
            ViewBag.v2 = "Projeler";
            ViewBag.Url = "/Portfolio/Index";
            var values = _portfolioService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddPortfolio()
        {
            ViewBag.v1 = "Proje Ekleme";
            ViewBag.v2 = "Projeler";
            ViewBag.Url = "/Portfolio/Index";
            return View();
        }
        [HttpPost]
        public IActionResult AddPortfolio(Portfolio p)
        {
            ViewBag.v1 = "Proje Ekleme";
            ViewBag.v2 = "Projeler";
            ViewBag.Url = "/Portfolio/Index";

            if (!ModelState.IsValid) return View();

            _portfolioService.TAdd(p);
                return RedirectToAction("Index");
        }
        public IActionResult DeletePortfolio(int id)
        {
            var values = _portfolioService.TGetByID(id);
            _portfolioService.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditPortfolio(int id)
        {
            ViewBag.v1 = "Proje Güncelleme";
            ViewBag.v2 = "Projeler";
            ViewBag.Url = "/Portfolio/Index";
            var values = _portfolioService.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditPortfolio(Portfolio portfolio)
        {
            _portfolioService.TUpdate(portfolio);
            return RedirectToAction("Index");
        }
    }
}
