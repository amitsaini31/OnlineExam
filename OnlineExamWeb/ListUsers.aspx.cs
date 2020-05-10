using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineExamWeb
{
    public partial class ListUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnapi.Value = Convert.ToString(Application["api"]);

            string code = Request.QueryString["code"];
            hdncode.Value = code;

            if (Session["user"] != null)
            {
                DataSet ds = (DataSet)Session["user"];
                //string user = ausername.InnerHtml = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                hdnu.Value = Convert.ToString(ds.Tables[0].Rows[0]["UserID"]);
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}