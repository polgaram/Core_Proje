using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class SkillController : Controller
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        public IActionResult Index()
        {
            ViewBag.v1 = "Yetenek Listesi";
            ViewBag.v2 = "Yetenekler";
            ViewBag.Url = "/Skill/Index";
            var values = _skillService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddSkill()
        {
            ViewBag.v1 = "Yetenek Ekleme";
            ViewBag.v2 = "Yetenekler";
            ViewBag.Url = "/Skill/Index";
            return View();
        }
        [HttpPost]
        public IActionResult AddSkill(Skill skill)
        {
            _skillService.TAdd(skill);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteSkill(int id)
        {
            var values= _skillService.TGetByID(id);
            _skillService.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditSkill(int id)
        {
            ViewBag.v1 = "Yetenek Güncelleme";
            ViewBag.v2 = "Yetenekler";
            ViewBag.Url = "/Skill/Index";
            var values = _skillService.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditSkill(Skill skill)
        {
            _skillService.TUpdate(skill);
            return RedirectToAction("Index");
        }
    }
}
