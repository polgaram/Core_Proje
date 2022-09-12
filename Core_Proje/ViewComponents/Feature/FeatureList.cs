using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Feature
{
    public class FeatureList:ViewComponent
    {
        private readonly IFeatureService _featureService;

        public FeatureList(IFeatureService featureService)
        {
            _featureService = featureService;
        }
        public IViewComponentResult Invoke()
        {
            var values= _featureService.TGetList();
            return View(values);
        }
    }
}
