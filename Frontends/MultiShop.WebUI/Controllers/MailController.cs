using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MultiShop.WebUI.Models;
namespace MultiShop.WebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult SendMail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMail(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("MultiShop Katalog", "denememardin0147@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            mimeMessage.Subject = mailRequest.Subject;
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = mailRequest.MessageContent;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("denememardin0147@gmail.com", "apmetyokiyxtdvwm");
            client.Send(mimeMessage);
            client.Disconnect(true);
            return View();
        }
    }
}
