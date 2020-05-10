using OnlineExamWeb.BusinessLogics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineExamWeb
{
    public partial class TestComplete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string user = "";
            if (Session["user"] != null)
            {
                DataSet ds = (DataSet)Session["user"];
                user = Convert.ToString(ds.Tables[0].Rows[0]["UserID"]);
                //hdnu.Value = Convert.ToString(ds.Tables[0].Rows[0]["UserID"]);
                //ausername.InnerHtml = user;
               
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

            string code = Request.QueryString["code"];
            GetResult(code, user);

        }

        public void GetResult(string code, string user)
        {
            Methods methods = new Methods();
            DataSet ds1 = methods.FETCH_RESULT(code, user);

            hTotalQuestions.InnerHtml = "Total Questions : "+ ds1.Tables[0].Rows[0]["A"];
            hTotalAttemptQuestions.InnerHtml = "Attempted Questions : " + ds1.Tables[0].Rows[0]["B"];
            hTotalCorrectQuestions.InnerHtml = "Correct Answers : " + ds1.Tables[0].Rows[0]["C"];
            hMarksObtained.InnerHtml = "Marks Obtained : " + ds1.Tables[0].Rows[0]["D"] + "%";
            dvRedirect.InnerHtml = "<a class='btn btn-primary' role='button' href='Test.aspx?code=" + code + "'>RETEST</a>";
        }
    }
}