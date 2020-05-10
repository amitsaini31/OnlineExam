using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using OnlineExamWeb.BusinessLogics;
using System.Data;

namespace OnlineExamWeb
{
    public partial class Visitor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnapi.Value = Convert.ToString(Application["api"]);
            if (Session["user"] != null)
            {
                DataSet ds1 = (DataSet)Session["user"];
                hdnu.Value = Convert.ToString(ds1.Tables[0].Rows[0]["UserID"]);
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            //Methods methods = new Methods();
            //methods.INSERT_BATCH(hdnid.Value, txtbatchname.Value, txtbatchdesc.Value, hdnu.Value);
        }
    }
}