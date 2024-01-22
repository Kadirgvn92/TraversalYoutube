using AutoMapper.Internal;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TraversalYoutube.DTOLayer.DTOs.AppUserDTOs;
using TraversalYoutube.EntityLayer.Concrete;
using TraversalYoutube.PresentationLayer.Gitignore;
using TraversalYoutube.PresentationLayer.Models;

namespace TraversalYoutube.PresentationLayer.Controllers;
public class PasswordChangeController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    public PasswordChangeController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }
    [HttpGet]
    public IActionResult ForgetPassword()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel forgetPasswordViewModel)
    {
        var user = await _userManager.FindByEmailAsync(forgetPasswordViewModel.Mail);
        if (user == null)
        {
            ViewBag.ErrorMessage = "Bu e-posta adresine sahip kullanıcı bulunamadı.";
            return View();
        }
        string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
        var passwordResetTokenLink = Url.Action("ResetPassword", "PasswordChange", new
        {
            userId = user.Id,
            token = passwordResetToken
        }, HttpContext.Request.Scheme);

        MimeMessage mimeMessage = new MimeMessage();
        MailboxAddress mailboxAddressFrom = new MailboxAddress("Traversal MailService", "kadirgvn92@gmail.com");
        mimeMessage.From.Add(mailboxAddressFrom);

        MailboxAddress mailboxAddressTo = new MailboxAddress("User", forgetPasswordViewModel.Mail);
        mimeMessage.To.Add(mailboxAddressTo);

        var bodyBuilder = new BodyBuilder();
        bodyBuilder.HtmlBody = passwordResetTokenLink;

        mimeMessage.Body = bodyBuilder.ToMessageBody();
        //mimeMessage.Body = mailRequest.Body;
        mimeMessage.Subject = "Şifre Değişiklik Talebi";

        SmtpClient smtpClient = new SmtpClient();
        smtpClient.Connect("smtp.gmail.com", 587, false);
        smtpClient.Authenticate("kadirgvn92@gmail.com", MailPass.Password);
        smtpClient.Send(mimeMessage);
        smtpClient.Disconnect(true);

        return View();
    }
    [HttpGet]
    public IActionResult ResetPassword(string userid, string token)
    {
        TempData["userid"] = userid;
        TempData["token"] = token;

        return View();
    }
    [HttpPost]
    public async Task<IActionResult> ResetPassword(ResetPasswordDTO reset)
    {
        var userid = TempData["userid"];
        var token = TempData["token"];
        if (userid == null || token == null)
        {
            ViewBag.error = "Alanlar boş bırakılamaz";
        }
        var user = await _userManager.FindByIdAsync(userid.ToString());
        var result = await _userManager.ResetPasswordAsync(user, token.ToString(), reset.Password);
        if (result.Succeeded)
        {
            return RedirectToAction("SignIn", "Login");
        }
        return View();
    }
}
