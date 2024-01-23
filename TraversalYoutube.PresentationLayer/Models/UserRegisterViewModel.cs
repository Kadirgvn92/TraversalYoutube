using System.ComponentModel.DataAnnotations;

namespace TraversalYoutube.PresentationLayer.Models;

public class UserRegisterViewModel
{
    public string Name { get; set; }

    public string Surname { get; set; }

    public string  Username{ get; set; }

    public string  Mail{ get; set; }

    public string  PhoneNumber{ get; set; }

    public string  ImageUrl{ get; set; }

    public string  Password{ get; set; }
    public string ConfirmPassword { get; set; }
}
