using ECommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Models.DTOs
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Ad girişi zorunludur.")]
        [Display(Name = "Ad")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad girişi zorunludur.")]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı girişi zorunludur.")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre girişi zorunludur.")]
        [Display(Name = "Kullanıcı Şifresi")]
        [DataType(DataType.Password, ErrorMessage = "Şireniz gerekli kriterleri sağlamıyor.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre tekrarı girilmesi zorunludur.")]
        [Display(Name = "Kullanıcı Şifresi Tekrar")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Şifreler birbirlerine eşit olmalıdır.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email adresi girişi zorunludur.")]
        [Display(Name = "E-Posta")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-Posta bilgilerinizi kontrol ediniz. Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }

        [Display(Name = "Adres")]
        public string Address { get; set; }

        public DateTime CreateDate => DateTime.Now;

        public Status Status => Status.Active;
    }
}
