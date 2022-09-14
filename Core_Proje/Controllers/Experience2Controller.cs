using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq.Expressions;

namespace Core_Proje.Controllers
{
    public class Experience2Controller : Controller
    {
        private readonly IExperienceService _experienceService;

        public Experience2Controller(IExperienceService experienceService)
        {
            _experienceService = experienceService;
        }
        public IActionResult Index()
        {
            ViewBag.v1 = "Deneyim Listesi";
            ViewBag.v2 = "Deneyimler";
            ViewBag.Url = "/Experience2/Index";
            return View();
        }
        public IActionResult ListExperience()
        {

            var values = JsonConvert.SerializeObject(_experienceService.TGetList());
            return Json(values);
        }
        [HttpPost]
        public IActionResult AddExperience(Experience p)
        {
            _experienceService.TAdd(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }

        public IActionResult GetById(int ExperienceID)
        {
            var values =  JsonConvert.SerializeObject(_experienceService.TGetByID(ExperienceID));
            return Json(values);
        }
        public IActionResult DeleteExperience(int id)
        {
            var values = _experienceService.TGetByID(id);
            _experienceService.TDelete(values);
            return NoContent();
        }
        public IActionResult UpdateExperience(Experience p)
        {
            _experienceService.TUpdate(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }
    }
}
