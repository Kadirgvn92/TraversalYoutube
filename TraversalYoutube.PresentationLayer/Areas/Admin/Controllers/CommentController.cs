using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Abstract;
using TraversalYoutube.BusinessLayer.Concrete;
using TraversalYoutube.DataAccessLayer.EntityFramework;

namespace TraversalYoutube.PresentationLayer.Areas.Admin.Controllers;
[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
public class CommentController : Controller
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    public IActionResult Index()
    {
        
        var values = _commentService.TGetAll();
        return View(values);
    }

    public IActionResult DeleteComment(int id )
    {
        var values = _commentService.TGetByID(id);
        _commentService.TDelete(values);
        return RedirectToAction("Index", "Profile", new { area = "Admin" });
    }
}
