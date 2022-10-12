using BusinessLayer.Concrete;
using Core_Proje.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/{controller}/{action}/{id?}")]
    public class ProfileController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;

        public ProfileController(UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel
            {
                Name = values.Name,
                SurName = values.SurName,
                PictureUrl = values.ImageUrl
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (p.Password != null)
            {
                user.Name = p.Name;
                user.SurName = p.SurName;
                if (p.NewPassword != null && p.PasswordConfirm != null)
                {
                    var passwordCheck = _userManager.CheckPasswordAsync(user, p.Password);
                    if (passwordCheck.IsCompletedSuccessfully)
                    {
                        user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.NewPassword);
                    }
                }
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return Redirect("/Writer/DashboardWriter/Index/");
                }
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> UpdateImage()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel
            {
                PictureUrl = values.ImageUrl
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateImage(UserEditViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (p.Picture != null)
                {
                    var resource = Directory.GetCurrentDirectory();
                    var extension = Path.GetExtension(p.Picture.FileName);
                    var imagename = Guid.NewGuid() + extension;
                    var savelocation = $"{resource}/wwwroot/userimage/{imagename}";
                    var stream = new FileStream(savelocation, FileMode.Create);
                    await p.Picture.CopyToAsync(stream);
                    user.ImageUrl = imagename;
                }

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return Redirect("/Writer/DashboardWriter/Index/");
                }
            return View();
        }

    }
}
