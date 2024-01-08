using System.ComponentModel.DataAnnotations;

namespace TraversalYoutube.PresentationLayer.Areas.Member.Models;

public class UserEditViewModel
{
    public string name { get; set; }
    public string surname { get; set; }
    public string phonenumber { get; set; }
    public string mail { get; set; }
    public string imageurl { get; set; }
    public string password { get; set; }

    [Compare("password", ErrorMessage = "Şifreler uyumsuz")]
    public string confirmpassword { get; set; }
    public IFormFile? Image { get; set; }
}
