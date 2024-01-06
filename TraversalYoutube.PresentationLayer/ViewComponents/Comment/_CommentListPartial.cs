using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Concrete;
using TraversalYoutube.DataAccessLayer.EntityFramework;

namespace TraversalYoutube.PresentationLayer.ViewComponents.Comment;

public class _CommentListPartial : ViewComponent
{
    CommentManager commentManager = new CommentManager(new EfCommentDal());
    public IViewComponentResult Invoke(int id)
    {
        var values = commentManager.TGetDestinationByID(id);
        return View(values);
    }
}
