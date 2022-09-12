using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Skill
{
    public class SkillList : ViewComponent
    {
        private readonly ISkillService _skillService;

        public SkillList(ISkillService skillService)
        {
            _skillService = skillService;
        }
        public IViewComponentResult Invoke()
        {
            var values = _skillService.TGetList();
            return View(values);
        }
    }
}
