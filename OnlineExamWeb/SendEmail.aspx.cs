using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineExamWeb
{
    public partial class SendEmail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {

            try
            {
                //Create the msg object to be sent
                MailMessage msg = new MailMessage();
                //Add your email address to the recipients
                msg.To.Add(txtEmail.Text);
                if(txtCCEmail.Text.Trim() != "")
                {
                    msg.CC.Add(txtCCEmail.Text);
                }
                
                //Configure the address we are sending the mail from
                MailAddress add = new MailAddress("edw@edigitalwiki.com");
                msg.From = add;
                msg.Subject = txtSubject.Text;
                msg.Body = txtBody.Value;
                msg.IsBodyHtml = true;

                //Configure an SmtpClient to send the mail.            
                SmtpClient client = new SmtpClient();
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = false;
                //client.Host = "smtpout.secureserver.net";
                client.Host = "relay-hosting.secureserver.net";
                client.Port = 25;

                //Setup credentials to login to our sender email address ("UserName", "Password")
                NetworkCredential credentials = new NetworkCredential("edw@edigitalwiki.com", "EDW_arp@12345");
                client.UseDefaultCredentials = true;
                client.Credentials = credentials;

                //Send the msg
                client.Send(msg);
                txtEmail.Text = "";
                txtCCEmail.Text = "";
                txtSubject.Text = "";
                txtBody.Value = "";
                //Display some feedback to the user to let them know it was sent
            }
            catch (Exception ex)
            {
                throw ex;
                //If the message failed at some point, let the user know
                //"Your message failed to send, please try again."
            }
        }

    }


}