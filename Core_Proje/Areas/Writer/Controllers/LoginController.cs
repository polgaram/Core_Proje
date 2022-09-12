using BusinessLayer.Concrete;
using Core_Proje.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/{controller}/{action}/{id?}")]
    public class LoginController : Controller
    {
        private readonly UserManager<WriterUser> _userManager;
        private readonly SignInManager<WriterUser> _signInManager;

        public LoginController(SignInManager<WriterUser> signInManager, UserManager<WriterUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel p, string? returnUrl)
        {
            if (ModelState.IsValid)
            {
                WriterUser user = _userManager.Users.FirstOrDefault(t => t.Email == p.Mail);
                if (user != null)
                {
                    bool userLocked = await _userManager.IsLockedOutAsync(user);
                    if (userLocked)
                    {
                        ViewBag.Error = "Kullanıcınız kilitlenmiştir.";
                        return View();
                    }

                    var result = await _signInManager.PasswordSignInAsync(user, p.Password, true, true);
                    if (result.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "DashboardWriter");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Hatalı kullanıcı adı veya şifre!");
                        ViewBag.Error = "Hatalı kullanıcı adı veya şifre!";
                    }

                }
                else
                {
                    ViewBag.Error = "Hatalı kullanıcı adı veya şifre!";
                    return View();
                }
            }
            return View();

        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
