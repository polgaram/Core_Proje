using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Experience
    {
        public int ExperienceID { get; set; }
        [Required(ErrorMessage = "Ad alanı boş geçilemez")]
        [MinLength(1,ErrorMessage = "Ad alanı 1 karakterden küçük olamaz")]
        [MaxLength(100,ErrorMessage = "Ad alanı 100 karakterden büyük olamaz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Başlık alanı boş geçilemez")]
        [MinLength(1, ErrorMessage = "Başlık alanı 1 karakterden küçük olamaz")]
        [MaxLength(100, ErrorMessage = "Başlık alanı 100 karakterden büyük olamaz")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Tarih alanı boş geçilemez")]
        [MinLength(4, ErrorMessage = "Tarih alanı 4 karakterden küçük olamaz")]
        [MaxLength(50, ErrorMessage = "Tarih alanı 50 karakterden büyük olamaz")]
        public string Date { get; set; }
        
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
