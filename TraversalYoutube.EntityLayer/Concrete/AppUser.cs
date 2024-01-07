using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalYoutube.EntityLayer.Concrete;
public class AppUser : IdentityUser<int> //IdentityUser içine ID olarak kullanacağımız tipi giriyouruz biz int girdik
{
    public string ImageUrl { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Gender { get; set; }
}
