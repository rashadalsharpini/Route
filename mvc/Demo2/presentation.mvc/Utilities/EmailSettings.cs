using System.Net;
using System.Net.Mail;

namespace presentation.mvc.Utilities;

public static class EmailSettings
{
    public static void SendEmail(Email email)
    {
        var client = new SmtpClient("smtp.gmail.com", 587);
        client.EnableSsl = true;
        client.Credentials = new NetworkCredential("rashadalsharpini@gmail.com", "fmxiqrpfxokhfbkt");
        client.Send("rashadalsharpini@gmail.com", email.To, email.Subject, email.Body);
    }
}