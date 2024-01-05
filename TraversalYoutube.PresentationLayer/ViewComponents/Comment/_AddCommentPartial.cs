using Microsoft.AspNetCore.Mvc;

namespace TraversalYoutube.PresentationLayer.ViewComponents.Comment;

public class _AddCommentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
