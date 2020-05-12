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
            string to = "amit.s.kr31@gmail.com"; //To address    
            string from = "edw@edigitalwiki.com"; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = "In this article you will learn how to send a email using Asp.Net & C#";
            message.Subject = "Testing of Sending Email Using Asp.Net & C#";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("relay-hosting.secureserver.net", 25); //Gmail smtp    
            //SmtpClient client = new SmtpClient("smtpout.secureserver.net", 465); //Gmail smtp    
            client.EnableSsl = true;

            client.Credentials = new
            NetworkCredential("edw@edigitalwiki.com", "EDW_arp@12345");
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btn_SendMessage_Click(object sender, EventArgs e)
        {
            string to = "amit.s.kr31@gmail.com"; //To address    
            string from = "edw@edigitalwiki.com"; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = "In this article you will learn how to send a email using Asp.Net & C#";
            message.Subject = "Testing of Sending Email Using Asp.Net & C#";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtpout.secureserver.net", 465); //Gmail smtp    
            //SmtpClient client = new SmtpClient("smtpout.secureserver.net", 465); //Gmail smtp    
            client.EnableSsl = true;

            client.Credentials = new
            NetworkCredential("edw@edigitalwiki.com", "EDW_arp@12345");
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


        static string smtpAddress = "relay-hosting.secureserver.net";
        static int portNumber = 25;
        static bool enableSSL = true;
        static string emailFromAddress = "edw@edigitalwiki.com"; //Sender Email Address  
        static string password = "EDW_arp@12345"; //Sender Password  
        static string emailToAddress = "amit.s.kr31@gmail.com"; //Receiver Email Address  
        static string subject = "Hello";
        static string body = "Hello, This is Email sending test using gmail.";
       
        public static void SendMessage()
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(emailFromAddress);
                mail.To.Add(emailToAddress);
                mail.Subject = subject;
                mail.Body = body;
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));//--Uncomment this to send any attachment  
                using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                {
                    smtp.Credentials = new NetworkCredential(emailFromAddress, password);
                    smtp.EnableSsl = enableSSL;
                    smtp.Send(mail);
                }
            }
        }

        public void SEndGmail()
        {
            string to = "amit.s.kr31@gmail.com"; //To address    
            string from = "rajeshp2988@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = "In this article you will learn how to send a email using Asp.Net & C#";
            message.Subject = "Sending Email Using Asp.Net & C#";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("rajeshp2988@gmail.com", "password");
            client.EnableSsl = true;
            client.UseDefaultCredentials = true;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }


}