using Newtonsoft.Json;
using OnlineExamWeb.BusinessLogics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineExamWeb
{
    public partial class Question : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnapi.Value = Convert.ToString(Application["api"]);

            if (Request.QueryString["code"] == null)
            {
                ViewState["QuestionPaperCode"] = Convert.ToString(Session["QuestionPaperCode"]);
            }
            else
            {
                ViewState["QuestionPaperCode"] = Session["QuestionPaperCode"] = Convert.ToString(Request.QueryString["code"]);

            }

            txtQuestionPaperCode.Text = hdncode.Value = Convert.ToString(ViewState["QuestionPaperCode"]);
            htitle.InnerHtml = "List of Questions in Question Paper : " + hdncode.Value;
            if (Session["user"] != null)
            {
                DataSet ds = (DataSet)Session["user"];
                string user = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                string userid = Convert.ToString(ds.Tables[0].Rows[0]["UserID"]);
                ausername.InnerHtml = user;
                dvAdd.Visible = false;
                dvView.Visible = true;
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["ecode"] != null)
                {

                    string id = Convert.ToString(Request.QueryString["ecode"]);
                    string user = "";
                    if (Session["user"] != null)
                    {
                        DataSet ds = (DataSet)Session["user"];
                        user = Convert.ToString(ds.Tables[0].Rows[0]["UserID"]);
                    }

                    Methods methods = new Methods();
                    DataSet ds1 = methods.FETCH_QUESTION2(id, user);

                    hdnid.Value = Convert.ToString(ds1.Tables[0].Rows[0]["ID"]);
                    txtQuestion.Value = Convert.ToString(ds1.Tables[0].Rows[0]["Question"]);
                    txtMCQ1.Value = Convert.ToString(ds1.Tables[0].Rows[0]["MCQ1"]);
                    txtMCQ2.Value = Convert.ToString(ds1.Tables[0].Rows[0]["MCQ2"]);
                    txtMCQ3.Value = Convert.ToString(ds1.Tables[0].Rows[0]["MCQ3"]);
                    txtMCQ4.Value = Convert.ToString(ds1.Tables[0].Rows[0]["MCQ4"]);
                    ddlAnswer.SelectedValue = Convert.ToString(ds1.Tables[0].Rows[0]["Answer"]);
                    txtExplaination.Value = Convert.ToString(ds1.Tables[0].Rows[0]["Explaination"]);
                    dvAdd.Visible = true;
                    dvView.Visible = false;

                }

                if (Request.QueryString["dcode"] != null)
                {
                    string id = Convert.ToString(Request.QueryString["dcode"]);
                    string user = "";
                    if (Session["user"] != null)
                    {
                        DataSet ds = (DataSet)Session["user"];
                        user = Convert.ToString(ds.Tables[0].Rows[0]["UserID"]);
                    }
                    Methods methods = new Methods();
                    methods.DELETE_QUESTION(id, user);
                    dvAdd.Visible = false;
                    dvView.Visible = true;
                }
            }
        }

        public string GetQuestionPaperCode(string QuestionPaperCode)
        {
            Methods methods = new Methods();
            DataSet ds = methods.FETCH_QUESTION_PAPER_CODE(QuestionPaperCode);

            string ID = Convert.ToString(ds.Tables[0].Rows[0]["ID"]);

            return ID;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                string user = "";
                if (Session["user"] != null)
                {
                    DataSet ds1 = (DataSet)Session["user"];
                    user = Convert.ToString(ds1.Tables[0].Rows[0]["UserID"]);
                }

                string QuestionPaperCodeID = GetQuestionPaperCode(txtQuestionPaperCode.Text);
                string question = txtQuestion.Value;
                string mcq1 = txtMCQ1.Value;
                string mcq2 = txtMCQ2.Value;
                string mcq3 = txtMCQ3.Value;
                string mcq4 = txtMCQ4.Value;
                string answer = ddlAnswer.SelectedValue;
                string explaination = txtExplaination.Value;
                

               Methods methods = new Methods();
                methods.INSERT_QUESTION(QuestionPaperCodeID, hdnid.Value, question, mcq1, mcq2, mcq3, mcq4, answer, explaination, user);

                txtQuestion.Value = "";
                txtMCQ1.Value = "";
                txtMCQ2.Value = "";
                txtMCQ3.Value = "";
                txtMCQ4.Value = "";
                txtExplaination.Value = "";
                ddlAnswer.SelectedValue = "0";
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            dvAdd.Visible = true;
            dvView.Visible = false;

            hdnid.Value = "0";
            txtQuestion.Value = "";
            txtMCQ1.Value = "";
            txtMCQ2.Value = "";
            txtMCQ3.Value = "";
            txtMCQ4.Value = "";
            txtExplaination.Value = "";
            ddlAnswer.SelectedValue = "0";
        }
    }
}
