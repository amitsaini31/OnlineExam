using OnlineExamWeb.BusinessLogics;
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
            
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            Methods methods = new Methods();
            if (methods.SendEmail(txtEmail.Text, txtCCEmail.Text, txtSubject.Text, txtBody.Value))
            {
                txtEmail.Text = "";
                txtCCEmail.Text = "";
                txtSubject.Text = "";
                txtBody.Value = "";
            }
        }

    }


}