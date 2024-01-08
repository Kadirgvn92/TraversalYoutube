using System.ComponentModel.DataAnnotations;

namespace TraversalYoutube.PresentationLayer.Areas.Member.Models;

public class UserEditViewModel
{
    [Required(ErrorMessage = "Ad alanı boş geçilemez")]
    public string? name { get; set; }
    [Required(ErrorMessage = "Soyad alanı boş geçilemez")]
    public string? surname { get; set; }
    [Required(ErrorMessage = "Şifre alanı boş geçilemez")]
    public string? password { get; set; }

    [Required(ErrorMessage = "Şifre tekrar alanı boş geçilemez")]
    [Compare("password", ErrorMessage = "Şifreler uyumlu değil")]
    public string? confirmpassword { get; set; }

    [Required(ErrorMessage = "Telefon Numara alanı boş geçilemez")]
    public string? phonenumber { get; set; }
    [Required(ErrorMessage = "Mail alanı boş geçilemez")]
    public string? mail { get; set; }
    [Required(ErrorMessage = "Resim alanı boş geçilemez")]
    public string? imageurl { get; set; }
    public IFormFile? Image { get; set; }
}
