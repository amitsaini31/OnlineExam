using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineExamWeb
{
    public partial class Error : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Convert.ToString(Session["Error"]);
        }
    }
}