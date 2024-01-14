using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Abstract;
using TraversalYoutube.DTOLayer.DTOs.AnnouncementDTOs;
using TraversalYoutube.EntityLayer.Concrete;
using TraversalYoutube.PresentationLayer.Areas.Admin.Models;

namespace TraversalYoutube.PresentationLayer.Areas.Admin.Controllers;
[AllowAnonymous]
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
        List<Announcement> announcements = _announcementService.TGetAll();
        List<AnnouncementListViewModel> list = new List<AnnouncementListViewModel>();   
        foreach(var item in announcements)
        {
            AnnouncementListViewModel announcementListViewModel = new AnnouncementListViewModel();
            announcementListViewModel.ID = item.AnnouncementID;
            announcementListViewModel.Title = item.Title;
            announcementListViewModel.Content = item.Content;
            list.Add(announcementListViewModel);
        }
        return View(list);
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
