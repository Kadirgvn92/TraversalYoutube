using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Abstract;
using TraversalYoutube.DTOLayer.DTOs.AnnouncementDTOs;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.PresentationLayer.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]/[action]/{id?}")]
[Authorize(Roles = "Admin")]
public class AnnouncementController : Controller
{
    private readonly IAnnouncementService _announcementService;
    private readonly IMapper _mapper;

    public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
    {
        _announcementService = announcementService;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        var values = _mapper.Map<List<AnnouncementListDTO>>(_announcementService.TGetAll());
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
        if(ModelState.IsValid)
        {
            _announcementService.TAdd(new Announcement()
            {
                Content = announcementAddDTO.Content,
                Title = announcementAddDTO.Title,
                Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
            });

            return RedirectToAction("Index", "Announcement", new { area = "Admin" });
        }
        return View();
        
    }

    public IActionResult DeleteAnnouncement(int id)
    {
        var values = _announcementService.TGetByID(id);
        _announcementService.TDelete(values);
        return RedirectToAction("Index", "Announcement", new { area = "Admin" });
    }
    [HttpGet]
    public IActionResult UpdateAnnouncement(int id)
    {
        var values = _mapper.Map<AnnouncementUpdateDTO>(_announcementService.TGetByID(id));
        return View(values);
    }
    [HttpPost]
    public IActionResult UpdateAnnouncement(AnnouncementUpdateDTO announcementUpdateDTO)
    {
        if(ModelState.IsValid)
        {
            _announcementService.TUpdate(new Announcement()
            {
                AnnouncementID = announcementUpdateDTO.AnnouncementID,
                Content = announcementUpdateDTO.Content,
                Title = announcementUpdateDTO.Title,
                Date = Convert.ToDateTime((DateTime.Now.ToShortDateString()))
            });
            return RedirectToAction("Index", "Announcement", new { area = "Admin" });
        }
        return View();
    }

}
