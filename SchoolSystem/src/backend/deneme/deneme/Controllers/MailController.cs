using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using deneme.EfCore;
using deneme.Dtos.Student;

namespace deneme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly EF_DataContext _db;
        public MailController(EF_DataContext dataContext)
        {
            _db = dataContext;
        }
        [HttpPost]
        public async Task<IActionResult> SendMailAsync(int id, string MailAdress)
        {



            var email = new MimeMessage();
            
            email.From.Add(MailboxAddress.Parse("trycia.goldner31@ethereal.email"));
            email.To.Add(MailboxAddress.Parse(MailAdress));


            var user = await _db.Students.FindAsync(id);
            if (user == null)
            {

                email.Subject = "Veri tabanına kaydedilen bilgiler.";
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = "Kullanıcı bulunamadı" };

            }

            var namee = user.Name;
            var idd = user.Id;

            email.Subject = "Veri tabanına kaydedilen bilgiler.";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) {
                Text = "Kullanıcı Adı: "+namee +"\n"+" Kullanıcı Id: "+ idd
            };


            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate("trycia.goldner31@ethereal.email", "8bDBmv7wzEXkCzEhFG");
            smtp.Send(email);
            smtp.Disconnect(true);
            return Ok();
        }


    }
}
