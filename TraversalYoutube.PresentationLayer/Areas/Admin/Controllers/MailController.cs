using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TraversalYoutube.PresentationLayer.Gitignore;
using TraversalYoutube.PresentationLayer.Models;

namespace TraversalYoutube.PresentationLayer.Areas.Admin.Controllers;
[Area("Admin")]

[Route("Admin/[controller]/[action]/{id?}")]
[Authorize(Roles = "Admin")]
public class MailController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(MailRequest mailRequest)
    {
        MimeMessage mimeMessage = new MimeMessage();
        MailboxAddress mailboxAddressFrom = new MailboxAddress("Traversal MailService", "kadirgvn92@gmail.com");
        mimeMessage.From.Add(mailboxAddressFrom);

        MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);
        mimeMessage.To.Add(mailboxAddressTo);

        var bodyBuilder = new BodyBuilder();
        bodyBuilder.HtmlBody = mailRequest.Body;
        mimeMessage.Body = bodyBuilder.ToMessageBody();
        //mimeMessage.Body = mailRequest.Body;
        mimeMessage.Subject = mailRequest.Subject;

        SmtpClient smtpClient = new SmtpClient();
        smtpClient.Connect("smtp.gmail.com", 587, false);

        smtpClient.Authenticate("kadirgvn92@gmail.com", MailPass.Password);
        smtpClient.Send(mimeMessage);
        smtpClient.Disconnect(true);

        Task.Delay(1600);
        return RedirectToAction("Index","Dashboard",new {area = "Admin" });
    }
}
