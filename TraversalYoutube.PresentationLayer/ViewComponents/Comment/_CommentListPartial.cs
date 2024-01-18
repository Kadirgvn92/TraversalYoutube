using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Concrete;
using TraversalYoutube.DataAccessLayer.Concrete;
using TraversalYoutube.DataAccessLayer.EntityFramework;

namespace TraversalYoutube.PresentationLayer.ViewComponents.Comment;

public class _CommentListPartial : ViewComponent
{
    CommentManager commentManager = new CommentManager(new EfCommentDal());
    Context context = new Context();
    public IViewComponentResult Invoke(int id)
    {

        ViewBag.v3 = context.Comments.Where(x => x.DestinationID == id).Count();
        var values = commentManager.TGetListCommentWithDestinationAndUser(id);
        return View(values);
    }
}
