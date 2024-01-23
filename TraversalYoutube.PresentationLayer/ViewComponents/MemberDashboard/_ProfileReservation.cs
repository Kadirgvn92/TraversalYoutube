using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Concrete;
using TraversalYoutube.DataAccessLayer.EntityFramework;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.PresentationLayer.ViewComponents.MemberDashboard;

public class _ProfileReservation :ViewComponent
{
    ReservationManager reservationManager = new ReservationManager(new EfReservationDal());

    private readonly UserManager<AppUser> _userManager;

    public _ProfileReservation(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IViewComponentResult>  InvokeAsync()
    {
        var values2 = await _userManager.FindByNameAsync(User.Identity.Name);
        var values = reservationManager.TGetAllReservation(values2.Id);
        return View(values);
    }
}
