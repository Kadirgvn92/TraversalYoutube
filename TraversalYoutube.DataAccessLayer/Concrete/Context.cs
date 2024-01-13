using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.DataAccessLayer.Concrete;
public class Context : IdentityDbContext<AppUser,AppRole,int>
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=DESKTOP-A6C5CRN\\SQLEXPRESS;database=TraversalDb;integrated security=true;");
    }

    public DbSet<About> Abouts { get; set; }
    public DbSet<About2> About2s { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Destination> Destinations { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<Feature2> Feature2s { get; set; }
    public DbSet<Guide> Guides { get; set; }
    public DbSet<Newsletter> Newsletters { get; set; }
    public DbSet<SubAbout> SubAbouts { get; set; }
    public DbSet<Testimonail> Testimonails { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<ContactUs> ContactUses { get; set; }

    //burada yeni bir dbset oluşturup AppUser ve AppRole sınıfını tanımlamamaız
    //gerekmez çünkü IdentityDBContext miras aldığı için
}
