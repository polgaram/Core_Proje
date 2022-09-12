using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer.IdentityConfigurations
{
    public class InitialIdentityData
    {
        private readonly RoleManager<WriterRole> _roleManager;
        private readonly UserManager<WriterUser> _userManager;
        public InitialIdentityData(RoleManager<WriterRole> roleManager, UserManager<WriterUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task Do()
        {
            bool result = await _roleManager.RoleExistsAsync("Moderator");

            if (!result)
            {
                await _roleManager.CreateAsync(new WriterRole
                {
                    Name = "Moderator"
                });
            }

            result = await _roleManager.RoleExistsAsync("Writer");

            if (!result)
            {
                await _roleManager.CreateAsync(new WriterRole
                {
                    Name = "Writer"
                });
            }

            result = await _roleManager.RoleExistsAsync("Admin");

            if (!result)
            {
                await _roleManager.CreateAsync(new WriterRole
                {
                    Name = "Admin"
                });
            }

            bool userResult = _userManager.Users.Any(t => t.Email == "bozalp@turpak.com.tr");


            if (!userResult)
            {

                var admin = new WriterUser
                {
                    Email = "bozalp@turpak.com.tr",
                    NormalizedEmail = "BOZALP@TURPAK.COM.TR",
                    UserName = "bozalp",
                    NormalizedUserName = "BOZALP",
                    Name = "BURAK",
                    SurName = "ÖZALP",
                    PasswordHash = "AQAAAAEAACcQAAAAEHluiFXcq0Mu4C5K3vQ1ZNCYxA19jCYVCP+w5/KpZi2OLa8tDgGBx/7wi5H+KR8qwA==",
                    ImageUrl = ""

                };

                await _userManager.CreateAsync(admin);//adminden sonra , koy şifreyi yaz

                await _userManager.AddToRoleAsync(admin, "Admin");
                await _userManager.AddToRoleAsync(admin, "Writer");
                await _userManager.AddToRoleAsync(admin, "Moderator");
            }



        }

    }
}
