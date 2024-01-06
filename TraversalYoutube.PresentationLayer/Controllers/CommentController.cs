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
    public PartialViewResult AddComment(Comment comment)
    {
        comment.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        comment.CommentState = true;
        commentManager.TAdd(comment);
        return PartialView();
    }
}
