using Pizzeria.bl.MailModel;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace Pizzeria.MailServices
{
    public class SendMailRepository
    {
        public void PizzeriaSendOrder(MailSettings mailSettings, MailParams mailParams)
        {
            NetworkCredential login = new NetworkCredential(mailSettings.User, mailSettings.Pass);
            SmtpClient client = new SmtpClient(mailSettings.Smtptext);
            client.Port = mailSettings.Port;
            client.EnableSsl = mailSettings.Ssl;
            client.Credentials = login;
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(mailSettings.User);

            msg.To.Add(new MailAddress(mailParams.Totxt));

            if (!string.IsNullOrEmpty(mailParams.Cctxt))
                msg.To.Add(new MailAddress(mailParams.Cctxt));

            msg.Subject = mailParams.Subject;
            msg.Body = mailParams.Msgbody;
            msg.BodyEncoding = Encoding.UTF8;
            msg.Priority = MailPriority.Normal;
            msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            try
            {
                client.Send(msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            MessageBox.Show("Zamówienie zostało wysłane", "Information"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

    }
}
