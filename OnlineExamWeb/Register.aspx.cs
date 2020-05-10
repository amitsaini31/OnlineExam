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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void fnRegister()
        {
            try
            {


                string email = txtemail.Value;
                string password = txtpassword.Value;
                string confirmpassword = txtconfirmpassword.Value;
                if(password != confirmpassword)
                {
                    lblmessage.InnerText = "Password not matching.";
                    lblmessage.Visible = true;
                    return;
                }
                string role = ddlRole.SelectedValue;
                SqlConnection sqlCnn = new SqlConnection(ConfigurationManager.AppSettings["connectionstring"]);

                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd = new SqlCommand("INSERT_USER", sqlCnn);
                cmd.Parameters.Add(new SqlParameter("@email", email));
                cmd.Parameters.Add(new SqlParameter("@password", password));
                cmd.Parameters.Add(new SqlParameter("@role", role));
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
            fnRegister();
            fnLogin();


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

        public void fnLogin()
        {
            try
            {


                string email = txtemail.Value;
                string password = txtpassword.Value;
                string ipaddress = GetIPAddress();
                if (email == "" || password == "")
                {
                    lblmessage.InnerText = "Please enter details.";
                    lblmessage.Visible = true;
                    return;
                }
                Methods methods = new Methods();
                DataSet ds = methods.LOGIN_VALIDATE(email, password, ipaddress);


                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {

                    Session["user"] = ds;
                    string Role = Convert.ToString(ds.Tables[0].Rows[0]["Role"]);

                    //string url = "https://www.fast2sms.com/dev/bulk?authorization=4kBtaCichwHNnMRdP1QXGTLOjFv8ogUKu2Jx0y3p9IqZYV7el6soNik0rXMZU7cB3LKDaP2xYmuOR4td&sender_id=FSTSMS&message=Message%20from%20EDIGITALWIKI.COM%20Login%20User%20id%20" + email + "at%20" + DateTime.Now + "&language=english&route=p&numbers=8010411286,9968417816";
                    //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    //request.GetResponse();

                    switch (Role)
                    {
                        case "Visitor":
                            Response.Redirect("Visitor.aspx");
                            break;
                        case "Guest":
                            Response.Redirect("Visitor.aspx");
                            break;
                        case "Admin":
                            Response.Redirect("AdminHome.aspx");
                            break;
                        case "Institution":
                            Response.Redirect("InstitutionHome.aspx");
                            break;

                    }
                }
                else
                {
                    lblmessage.InnerText = "User Not Exists. Register First";
                    lblmessage.Visible = true;
                    return;
                }
            }
            catch (Exception)
            {
                lblmessage.InnerText = "Login Issue.";
                lblmessage.Visible = true;
                //throw;
            }
        }
    }
}