﻿using Microsoft.AspNetCore.Mvc;

namespace TraversalYoutube.PresentationLayer.ViewComponents.Default;

public class _SliderPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}
