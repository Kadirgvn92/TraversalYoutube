using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Concrete;
using TraversalYoutube.DataAccessLayer.EntityFramework;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.PresentationLayer.Controllers;
public class CommentController : Controller
{
    CommentManager commentManager = new CommentManager(new EfCommentDal());
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
        ViewBag.Comment = comment.DestinationID;
        commentManager.TAdd(comment);
        return RedirectToAction("Index","Destination");
    }
}
