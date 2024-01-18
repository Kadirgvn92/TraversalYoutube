using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Concrete;
using TraversalYoutube.DataAccessLayer.EntityFramework;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.PresentationLayer.Controllers;
public class CommentController : Controller
{
    CommentManager commentManager = new CommentManager(new EfCommentDal());
    private readonly UserManager<AppUser> _userManager;

    public CommentController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public PartialViewResult AddComment()
    {

        return PartialView();
    }
    [HttpPost]
    public IActionResult AddComment(Comment comment)
    {
        comment.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        comment.CommentState = true;
        comment.CommentUser = "Default";
        ViewBag.Comment = comment.DestinationID;
        commentManager.TAdd(comment);
        return RedirectToAction("Index","Destination");
    }
}
