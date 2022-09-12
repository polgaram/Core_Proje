﻿using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.ViewComponents
{
    public class Navbar:ViewComponent
    {
        private readonly UserManager<WriterUser> _userManager;

        public Navbar(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.ImageUrl = values.ImageUrl;
            return View();
        }

        //public IViewComponentResult Invoke()
        //{
        //    var values = _userManager.FindByNameAsync(User.Identity.Name).Result;
        //    ViewBag.ImageUrl = values.ImageUrl;
        //    return View();
        //}
    }
}
