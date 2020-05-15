using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace OnlineExamWeb.BusinessLogics
{


    public class Methods
    {
        SqlConnection sqlCnn = new SqlConnection(ConfigurationManager.AppSettings["connectionstring"]);

        public void PUBLISH_QUESTION_PAPER(string code)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds1 = new DataSet();

            cmd = new SqlCommand("PUBLISH_QUESTION_PAPER", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@code", code));

            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds1);
        }

        public void PUBLIC_QUESTION_PAPER(string code)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds1 = new DataSet();

            cmd = new SqlCommand("PUBLIC_QUESTION_PAPER", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@code", code));

            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds1);
        }

        public void DELETE_QUESTION_PAPER(string code, string user)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds1 = new DataSet();

            cmd = new SqlCommand("DELETE_QUESTION_PAPER", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@code", code));
            cmd.Parameters.Add(new SqlParameter("@user", user));

            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds1);
        }


        public DataSet FETCH_QUESTION_PAPER(string code, string user)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds1 = new DataSet();

            cmd = new SqlCommand("FETCH_QUESTION_PAPER", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@code", code));
            cmd.Parameters.Add(new SqlParameter("@user", user));

            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds1);
            return ds1;


        }

        public void INSERT_QUESTION_PAPER(string hdnid, string code, string title, string hiddentitle, string questioncount, string generalinstructions, string category, string user)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet(); 

            cmd = new SqlCommand("INSERT_QUESTION_PAPER", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@ID", hdnid));
            cmd.Parameters.Add(new SqlParameter("@code", code));
            cmd.Parameters.Add(new SqlParameter("@title", title));
            cmd.Parameters.Add(new SqlParameter("@hiddentitle", hiddentitle));
            cmd.Parameters.Add(new SqlParameter("@questioncount", questioncount));
            cmd.Parameters.Add(new SqlParameter("@generalinstructions", generalinstructions));
            cmd.Parameters.Add(new SqlParameter("@category", category));            
            cmd.Parameters.Add(new SqlParameter("@user", user));
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
        }

        public DataSet FETCH_QUESTION2(string id, string user)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds1 = new DataSet();

            cmd = new SqlCommand("FETCH_QUESTION2", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.Parameters.Add(new SqlParameter("@user", user));

            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds1);
            return ds1;
        }

        public void DELETE_QUESTION(string id, string user)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds1 = new DataSet();

            cmd = new SqlCommand("DELETE_QUESTION", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.Parameters.Add(new SqlParameter("@user", user));

            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds1);
        }


        public DataSet FETCH_QUESTION_PAPER_CODE(string QuestionPaperCode)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("FETCH_QUESTION_PAPER_CODE", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@QuestionPaperCode", QuestionPaperCode));
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            return ds;
        }

        public void INSERT_QUESTION(string QuestionPaperCodeID, string hdnid, string question, string mcq1, string mcq2, string mcq3, string mcq4, string answer, String explaination, string user)
        {


            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("INSERT_QUESTION", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@QuestionPaperCodeID", QuestionPaperCodeID));
            cmd.Parameters.Add(new SqlParameter("@ID", hdnid));
            cmd.Parameters.Add(new SqlParameter("@Question", question));
            cmd.Parameters.Add(new SqlParameter("@MCQ1", mcq1));
            cmd.Parameters.Add(new SqlParameter("@MCQ2", mcq2));
            cmd.Parameters.Add(new SqlParameter("@MCQ3", mcq3));
            cmd.Parameters.Add(new SqlParameter("@MCQ4", mcq4));
            cmd.Parameters.Add(new SqlParameter("@Answer", answer));
            cmd.Parameters.Add(new SqlParameter("@Explaination", explaination));
            cmd.Parameters.Add(new SqlParameter("@UserID", user));
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
        }

        public DataSet FETCH_RESULT(string code, string user)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds1 = new DataSet();

            cmd = new SqlCommand("FETCH_RESULT", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@code", code));
            cmd.Parameters.Add(new SqlParameter("@user", user));

            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds1);
            return ds1;
        }

        public DataSet LOGIN_VALIDATE(string email, string password, string ipaddress)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("LOGIN_VALIDATE", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@email", email));
            cmd.Parameters.Add(new SqlParameter("@password", password));
            cmd.Parameters.Add(new SqlParameter("@ipaddress", ipaddress));

            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            return ds;
        }

        public DataSet FILL_CATEGORY()
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("FILL_CATEGORY", sqlCnn);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            return ds;
        }


        public void INSERT_CATEGORY(string hdnid, string categoryname, string categorydesc, string user)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("INSERT_CATEGORY", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@ID", hdnid));
            cmd.Parameters.Add(new SqlParameter("@categoryname", categoryname));
            cmd.Parameters.Add(new SqlParameter("@categorydesc", categorydesc));
            cmd.Parameters.Add(new SqlParameter("@user", user));
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
        }
        public void INSERT_BATCH(string hdnid, string batchname, string batchdesc, string user)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("INSERT_BATCH", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@id", hdnid));
            cmd.Parameters.Add(new SqlParameter("@batchname", batchname));
            cmd.Parameters.Add(new SqlParameter("@batchdesc", batchdesc));
            cmd.Parameters.Add(new SqlParameter("@user", user));
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
        }

        public void INSERT_USER_BATCH(string batchid, string userid, string user)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("INSERT_USER_BATCH", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@batchid", batchid));
            cmd.Parameters.Add(new SqlParameter("@userid", userid));
            cmd.Parameters.Add(new SqlParameter("@user", user));
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
        }

        public DataSet FILL_QUESTION_PAPER(string user)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("FILL_QUESTION_PAPER", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@user", user));
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            return ds;
        }

        public DataSet FILL_BATCH(string user)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("FILL_BATCH", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@user", user));
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            return ds;
        }


        public bool SendEmail(string email, string cc, string subject, string body)
        {
            try
            {
                //Create the msg object to be sent
                MailMessage msg = new MailMessage();
                //Add your email address to the recipients
                msg.To.Add(email);
                if (cc.Trim() != "")
                {
                    msg.CC.Add(cc);
                }

                //Configure the address we are sending the mail from
                MailAddress add = new MailAddress("edw@edigitalwiki.com");
                msg.From = add;
                msg.Subject = subject;
                msg.Body = body;
                msg.IsBodyHtml = true;

                //Configure an SmtpClient to send the mail.            
                SmtpClient client = new SmtpClient();
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = false;
                //client.Host = "smtpout.secureserver.net";
                client.Host = ConfigurationManager.AppSettings["smtp"];
                client.Port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);

                //Setup credentials to login to our sender email address ("UserName", "Password")
                NetworkCredential credentials = new NetworkCredential(ConfigurationManager.AppSettings["user"], ConfigurationManager.AppSettings["pass"]);
                client.UseDefaultCredentials = true;
                client.Credentials = credentials;

                //Send the msg
                client.Send(msg);
               
                return true;
                //Display some feedback to the user to let them know it was sent
            }
            catch (Exception ex)
            {
                //throw ex;
                return false;
                //If the message failed at some point, let the user know
                //"Your message failed to send, please try again."
            }
            
        }
        
    }
}