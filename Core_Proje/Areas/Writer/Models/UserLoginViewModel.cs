using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Core_Proje.Areas.Writer.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Lüften mail adresinizi giriniz")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Lüften şifrenizi giriniz")]
        public string Password { get; set; }
    }
}
