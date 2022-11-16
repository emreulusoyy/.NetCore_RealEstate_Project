using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using RealEstate.PresentationLayer.Models;

namespace RealEstate.PresentationLayer.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(MailRequest p)
        {
            MimeMessage mimeMessage = new MimeMessage();
            //MAili yollayan
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin RealEstate","eulusoy139@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            //mailin gönderileceği kişi
            MailboxAddress mailboxAddressTo = new MailboxAddress("User", p.ReciverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodybuilder = new BodyBuilder();
            bodybuilder.TextBody = p.Content; //İçeriğin ne olduğunu belirttik.
            mimeMessage.Body = bodybuilder.ToMessageBody();
            mimeMessage.Subject = p.Subject; 

            SmtpClient smtpClient = new SmtpClient();   
            smtpClient.Connect("smtp.gmail.com",587,false); // format ve port nmarası   
            smtpClient.Authenticate("eulusoy@gmail.com", "");
            smtpClient.Disconnect(true);

            return View();
        }
    }
}
