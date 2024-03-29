﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Abstract;
using TraversalYoutube.DTOLayer.DTOs.ContactDTOs;
using TraversalYoutube.EntityLayer.Concrete;

namespace TraversalYoutube.PresentationLayer.Controllers;
[AllowAnonymous]
public class ContactController : Controller
{
    private readonly IContactUsService _contactUsService;
    private readonly IMapper _mapper;

    public ContactController(IContactUsService contactUsService, IMapper mapper)
    {
        _contactUsService = contactUsService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Index(SendMessageDTO dTO) 
    {
        if(ModelState.IsValid)
        {
            _contactUsService.TAdd(new ContactUs()
            {
                MessageBody = dTO.MessageBody,
                Mail = dTO.Mail,
                MessageStatus = dTO.MessageStatus,
                Name = dTO.Name,
                Subject = dTO.Subject,
                MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
            }); 
            await Task.Delay(2000);
            return RedirectToAction("Index","Default");
        }
        return View();
    }
}
