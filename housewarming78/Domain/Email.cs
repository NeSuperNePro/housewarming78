using housewarming78.Service;
using MailKit.Net.Smtp;
using MimeKit;

namespace housewarming78.Domain
{
    public class Email
    {
        

        

        public void SendEmail(string validationName, string validationPhone)
        {
            try
            {
                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress(Config.CompnyName, "nesupernepro@yandex.ru"));
                message.To.Add(new MailboxAddress("", Config.CompnyEmail));
                message.Subject = "Mail service - " + Config.CompnyName;
                message.Body = new BodyBuilder()
                {
                    HtmlBody =
                    "<div>" +
                    "<h1><strong>Бесплатная консультация для </strong></h1>" +
                    "<label>" + validationName + " </label>" +
                    "<label>" + validationPhone + "</label>" +
                    "</div>"
                }.ToMessageBody();

                using (SmtpClient client = new SmtpClient())
                {
                    //nnomsrmnsqzptabj
                    client.Connect("smtp.yandex.ru", 25, false);
                    client.Authenticate("nesupernepro@yandex.ru", "nnomsrmnsqzptabj");
                    client.Send(message);

                    client.Disconnect(true);
                }

                
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());  
            }
        }
    }
}
