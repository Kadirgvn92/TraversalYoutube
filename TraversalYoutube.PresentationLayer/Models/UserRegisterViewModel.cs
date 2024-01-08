using System.ComponentModel.DataAnnotations;

namespace TraversalYoutube.PresentationLayer.Models;

public class UserRegisterViewModel
{
	[Required(ErrorMessage = "Ad alanı boş geçilemez")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Soyad alanı boş geçilemez")]
    public string Surname { get; set; }

    [Required(ErrorMessage = "Kullanıcı Adı alanı boş geçilemez")]
    public string  Username{ get; set; }

    [Required(ErrorMessage = "Mail alanı boş geçilemez")]
    public string  Mail{ get; set; }

    [Required(ErrorMessage = "Telefon Numarası alanı boş geçilemez")]
    public string  PhoneNumber{ get; set; }

    [Required(ErrorMessage = "Şifre alanı boş geçilemez")]
    public string  Password{ get; set; }

    [Required(ErrorMessage = "Şifre tekrar alanı boş geçilemez")]
    [Compare("Password", ErrorMessage = "Şifreler uyumlu değil")]
    public string ConfirmPassword { get; set; }
}
