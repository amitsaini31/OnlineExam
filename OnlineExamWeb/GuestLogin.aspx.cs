using OnlineExamWeb.BusinessLogics;
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
    public partial class GuestLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["user"] != null)
            //{
            //    DataSet ds = (DataSet)Session["user"];
            //    string Role = Convert.ToString(ds.Tables[0].Rows[0]["Role"]);
            //    switch (Role)
            //    {
            //        case "Visitor":
            //            Response.Redirect("VisitorHome.aspx");
            //            break;
            //        case "Admin":
            //            Response.Redirect("AdminHome.aspx");
            //            break;
            //        case "Institution":
            //            Response.Redirect("QuestionPaper.aspx");
            //            break;

            //    }
            //}

            fnRegister();
            fnLogin();

        }

        public void fnLogin()
        {
            try
            {


                string email = "Guest";
                string password = GetIPAddress();
                string ipaddress = GetIPAddress();

                Methods methods = new Methods();
                DataSet ds = methods.LOGIN_VALIDATE(email, password, ipaddress);


                Session["user"] = ds;
                string Role = Convert.ToString(ds.Tables[0].Rows[0]["Role"]);
                switch (Role)
                {
                    case "Visitor":
                        Response.Redirect("VisitorHome.aspx");
                        break;
                    case "Guest":
                        Response.Redirect("VisitorHome.aspx");
                        break;
                    case "Admin":
                        Response.Redirect("AdminHome.aspx");
                        break;
                    case "Institution":
                        Response.Redirect("QuestionPaper.aspx");
                        break;

                }

            }
            catch (Exception ex)
            {
                
            }
        }

        public void fnRegister()
        {
            try
            {


                SqlConnection sqlCnn = new SqlConnection(ConfigurationManager.AppSettings["connectionstring"]);

                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd = new SqlCommand("INSERT_USER", sqlCnn);
                cmd.Parameters.Add(new SqlParameter("@email", "Guest"));
                cmd.Parameters.Add(new SqlParameter("@password", GetIPAddress()));
                cmd.Parameters.Add(new SqlParameter("@role", "Guest"));
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(ds);
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void btnregister_Click(object sender, EventArgs e)
        {
           

        }

        public string GetIPAddress()
        {
            string IPAddress = "";
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