using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Abstract;
using TraversalYoutube.DTOLayer.DTOs.AnnouncementDTOs;

namespace TraversalYoutube.PresentationLayer.Areas.Admin.Controllers;

[Area("Admin")]
public class AnnouncementController : Controller
{
    private readonly IAnnouncementService _announcementService;

    public AnnouncementController(IAnnouncementService announcementService)
    {
        _announcementService = announcementService;
    }

    public IActionResult Index()
    {
        var values = _announcementService.TGetAll();
        return View(values);
    }
    [HttpGet]
    public IActionResult AddAnnouncement()
    {
        return View();  
    }
    [HttpPost]
    public IActionResult AddAnnouncement(AnnouncementAddDTO announcementAddDTO)
    {
        return View(announcementAddDTO);
    }
}
