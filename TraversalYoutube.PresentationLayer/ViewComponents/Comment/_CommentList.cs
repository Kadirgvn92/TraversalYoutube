using Microsoft.AspNetCore.Mvc;

namespace TraversalYoutube.PresentationLayer.ViewComponents.Comment;

public class _CommentList : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
