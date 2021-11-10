using System;
using System.Net.Mail;

namespace project
{
    public partial class footer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void sub_click(object sender,EventArgs e)
        {
            string body;
            if (sub.Value == "SUBSCRIBE")
            {
                sub.Value = "UNSUBSCRIBE";
                form1.Controls.Remove(email);
                body = "Thank You , For Subscribing With Kibblery...";
            }
            else
            {
                sub.Value = "SUBSCRIBE";
                body = "Sad to Know that you are UnSubscribing With Kibblery...";
            }
            try
            {
                MailMessage mmsg = new MailMessage("parmarhasti711@gmail.com",email.Value, "Subscribtion", body);
                mmsg.IsBodyHtml = true;
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("parmarhasti711@gmail.com", "711hastiparmar");
                client.Send(mmsg);
                Response.Redirect("https://localhost:44376/index.aspx", false);
            }
            catch (Exception e1)
            {
                Console.WriteLine(e1);
            }
        }
    }
}