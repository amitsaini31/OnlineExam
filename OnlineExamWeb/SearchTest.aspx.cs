using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineExamWeb
{
    public partial class SearchTest : System.Web.UI.Page
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
    }
}