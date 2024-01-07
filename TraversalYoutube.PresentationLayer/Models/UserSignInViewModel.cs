using System.ComponentModel.DataAnnotations;

namespace TraversalYoutube.PresentationLayer.Models;

public class UserSignInViewModel
{
    public string? Username { get; set; }

    public string? Password { get; set; }
}
