using System.ComponentModel.DataAnnotations;

namespace Core_Proje.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lüften adınızı giriniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lüften soyadınızı giriniz")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Lüften resminizin url' ini giriniz")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage ="Lüften kullanıcı adını giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lüften şifreyi giriniz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lüften şifreyi tekrar giriniz")]
        [Compare("Password",ErrorMessage ="Şifreler uyumlu değil!")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Lüften mail adresinizi giriniz")]
        public string Mail { get; set; }


    }
}
