﻿using Microsoft.AspNetCore.Mvc;

namespace TraversalYoutube.PresentationLayer.ViewComponents.Comment;

public class _CommentListPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
