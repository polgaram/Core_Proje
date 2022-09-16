using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Core_Proje.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly IExperienceService _experienceService;
        private readonly IValidator<Experience> _validator;

        public ExperienceController(IExperienceService experienceService, IValidator<Experience> validator)
        {
            _experienceService = experienceService;
            _validator = validator;
        }

        public IActionResult Index()
        {
            ViewBag.v1 = "Deneyim Listesi";
            ViewBag.v2 = "Deneyimler";
            ViewBag.Url = "/Experience/Index";
            var values = _experienceService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddExperience()
        {
            ViewBag.v1 = "Deneyim Ekleme";
            ViewBag.v2 = "Deneyimler";
            ViewBag.Url = "/Experience/Index";
            return View();
        }
        [HttpPost]
        public IActionResult AddExperienceAsync(Experience experience)
        {
            ValidationResult result = _validator.Validate(experience);
            if (!result.IsValid)
            {
                ModelState.Clear();
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }

            _experienceService.TAdd(experience);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteExperience(int id)
        {
            if (!ModelState.IsValid) return View();
            var values = _experienceService.TGetByID(id);
            _experienceService.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditExperience(int id)
        {

            ViewBag.v1 = "Deneyim Düzenleme";
            ViewBag.v2 = "Deneyimler";
            ViewBag.Url = "/Experience/Index";
            var values = _experienceService.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditExperience(Experience experience)
        {
            ValidationResult result = _validator.Validate(experience);
            if (!result.IsValid)
            {
                ModelState.Clear();
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }

            _experienceService.TUpdate(experience);
            return RedirectToAction("Index");
        }
    }
}
