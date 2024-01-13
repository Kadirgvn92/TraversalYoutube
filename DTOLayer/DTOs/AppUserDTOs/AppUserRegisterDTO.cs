using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalYoutube.DTOLayer.DTOs.AppUserDTOs;
public class AppUserRegisterDTO
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Username { get; set; }
    public string Mail { get; set; }
    public string PhoneNumber { get; set; }
    public string ImageUrl { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}
