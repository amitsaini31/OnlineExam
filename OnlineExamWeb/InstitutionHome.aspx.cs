using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineExamWeb.BusinessLogics;
using System.Data;

namespace OnlineExamWeb
{
    public partial class InstitutionHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnapi.Value = Convert.ToString(Application["api"]);
            if (Session["user"] != null)
            {
                DataSet ds1 = (DataSet)Session["user"];
                hdnu.Value = Convert.ToString(ds1.Tables[0].Rows[0]["UserID"]);
                hdnuname.Value = Convert.ToString(ds1.Tables[0].Rows[0]["Email"]);

            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}