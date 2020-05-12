using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineExamWeb.BusinessLogics;
using System.Data;

namespace OnlineExamWeb
{
    public partial class UserQuestion : System.Web.UI.Page
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
            dvAdd.Visible = false;
            dvView.Visible = true;

            if (!IsPostBack)
            {
                LoadQuestionPaper(hdnu.Value);

                if (Request.QueryString["ecode"] != null)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "myScript", "$.notify('Data Loaded successfully!', { type: 'info' });", true);
                    string id = Convert.ToString(Request.QueryString["ecode"]);
                    string user = "";
                    if (Session["user"] != null)
                    {
                        DataSet ds = (DataSet)Session["user"];
                        user = Convert.ToString(ds.Tables[0].Rows[0]["UserID"]);
                    }

                    Methods methods = new Methods();
                    DataSet ds1 = methods.FETCH_QUESTION2(id, user);
                    ddlQuestionPaper.SelectedValue = Convert.ToString(ds1.Tables[0].Rows[0]["QuestionPaperCodeID"]);
                    ViewState["id"] = hdnid.Value = id;
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

                string QuestionPaperCodeID = ddlQuestionPaper.SelectedValue;
                string question = txtQuestion.Value;
                string mcq1 = txtMCQ1.Value;
                string mcq2 = txtMCQ2.Value;
                string mcq3 = txtMCQ3.Value;
                string mcq4 = txtMCQ4.Value;
                string answer = ddlAnswer.SelectedValue;
                string explaination = txtExplaination.Value;
                if (hdnid.Value == "")
                    hdnid.Value = ViewState["id"].ToString();
                if (Convert.ToString(ViewState["id"]) != "")
                    hdnid.Value = Convert.ToString(ViewState["id"]);

                Methods methods = new Methods();
                methods.INSERT_QUESTION(QuestionPaperCodeID, hdnid.Value, question, mcq1, mcq2, mcq3, mcq4, answer, explaination, user);

                txtQuestion.Value = "";
                txtMCQ1.Value = "";
                txtMCQ2.Value = "";
                txtMCQ3.Value = "";
                txtMCQ4.Value = "";
                txtExplaination.Value = "";
                ddlAnswer.SelectedValue = "0";
                Response.Redirect("UserQuestion.aspx");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void LoadQuestionPaper(string userid)
        {

            Methods methods = new Methods();
            DataSet ds = methods.FILL_QUESTION_PAPER(userid);

            DataRow dr = ds.Tables[0].NewRow();
            dr[0] = 0;
            dr[1] = "--Select--";
            ds.Tables[0].Rows.InsertAt(dr,0);

            ddlQuestionPaper.DataSource = ds.Tables[0];
            ddlQuestionPaper.DataTextField = "QuestionPaperCode";
            ddlQuestionPaper.DataValueField = "ID";
            ddlQuestionPaper.DataBind();

        }

        public string GetQuestionPaperCode(string QuestionPaperCode)
        {
            Methods methods = new Methods();
            DataSet ds = methods.FETCH_QUESTION_PAPER_CODE(QuestionPaperCode);

            string ID = Convert.ToString(ds.Tables[0].Rows[0]["ID"]);

            return ID;
        }
    }
}