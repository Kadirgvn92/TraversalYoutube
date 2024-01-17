using Microsoft.AspNetCore.Mvc;
using TraversalYoutube.BusinessLayer.Abstract.AbstractUow;
using TraversalYoutube.EntityLayer.Concrete;
using TraversalYoutube.PresentationLayer.Areas.Admin.Models;

namespace TraversalYoutube.PresentationLayer.Areas.Admin.Controllers;
[Area("Admin")]

public class AccountController : Controller
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(AccountViewModel account)
    {
        var valueSender = _accountService.TGetByID(account.SenderID);
        var valuesReceiver = _accountService.TGetByID(account.ReceiverID);

        valueSender.Balance -= account.Amount;
        valuesReceiver.Balance += account.Amount;

        List<Account> modifiedAccount = new List<Account>()
        {
            valueSender,
            valuesReceiver
        };
        _accountService.TMultiUpdate(modifiedAccount);
        return View();
    }
}
