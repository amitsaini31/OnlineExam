using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineExamWeb
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnapi.Value = Convert.ToString(Application["api"]);
            string code = Request.QueryString["code"];
            hdncode.Value = code;
            if (Session["user"] != null)
            {
                DataSet ds = (DataSet)Session["user"];
                string user = Convert.ToString(ds.Tables[0].Rows[0]["UserID"]);
                string email = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                lblIPAdd.InnerHtml = "UserName : " +  Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                hdnu.Value = user;
                //ausername.InnerHtml = email;
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds1 = new DataSet();
            SqlConnection sqlCnn = new SqlConnection(ConfigurationManager.AppSettings["connectionstring"]);
            cmd = new SqlCommand("FETCH_QUESTION_BYCODE", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@code", code));

            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds1);

            //pgeneralinstructions.

        }


       

        public string GetIPAddress()
        {
            string IPAddress ="";
            IPHostEntry Host = default(IPHostEntry);
            string Hostname = null;
            Hostname = System.Environment.MachineName;
            Host = Dns.GetHostEntry(Hostname);
            foreach (IPAddress IP in Host.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    IPAddress = Convert.ToString(IP);
                }
            }
            return IPAddress;
        }

    }
}