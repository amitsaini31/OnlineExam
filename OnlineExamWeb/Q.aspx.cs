using Newtonsoft.Json;
using OnlineExamWeb.BusinessLogics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineExamWeb
{
    public partial class Q : System.Web.UI.Page
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

            hdncode.Value = Convert.ToString(ViewState["QuestionPaperCode"]);
            //hdnid.Value = Convert.ToString(ViewState["id"]);

            ddlQuestionPaper.Text = hdncode.Value = Convert.ToString(ViewState["QuestionPaperCode"]);
            htitle.InnerHtml = "List of Questions in Question Paper : " + hdncode.Value;
            if (Session["user"] != null)
            {
                DataSet ds = (DataSet)Session["user"];
                string user = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                string userid = Convert.ToString(ds.Tables[0].Rows[0]["UserID"]);

                LoadQuestionPaper(userid);

                //ausername.InnerHtml = user;
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

        public void LoadQuestionPaper(string userid)
        {

            Methods methods = new Methods();
            DataSet ds = methods.FILL_QUESTION_PAPER(userid);

            DataRow dr = ds.Tables[0].NewRow();
            dr[0] = 0;
            dr[1] = "--Select--";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            ddlQuestionPaper.DataSource = ds.Tables[0];
            ddlQuestionPaper.DataMember = "QuestionPaperCode";
            ddlQuestionPaper.DataValueField = "QuestionPaperCode";
            ddlQuestionPaper.DataBind();

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

                string QuestionPaperCodeID = GetQuestionPaperCode(ddlQuestionPaper.SelectedValue);
                string question = txtQuestion.Value;
                string mcq1 = txtMCQ1.Value;
                string mcq2 = txtMCQ2.Value;
                string mcq3 = txtMCQ3.Value;
                string mcq4 = txtMCQ4.Value;
                string answer = ddlAnswer.SelectedValue;
                string explaination = txtExplaination.Value;
                if (Convert.ToString(ViewState["id"])  != "")
                    hdnid.Value = Convert.ToString(ViewState["id"]);
                //if (hdnid.Value == "")
                //    hdnid.Value = Convert.ToString(ViewState["id"]) == "" ? "0" : Convert.ToString(ViewState["id"]);

                Methods methods = new Methods();
                methods.INSERT_QUESTION(QuestionPaperCodeID, hdnid.Value, question, mcq1, mcq2, mcq3, mcq4, answer, explaination, user);

                txtQuestion.Value = "";
                txtMCQ1.Value = "";
                txtMCQ2.Value = "";
                txtMCQ3.Value = "";
                txtMCQ4.Value = "";
                txtExplaination.Value = "";
                ddlAnswer.SelectedValue = "0";
                var code = Convert.ToString(ViewState["QuestionPaperCode"]);
                Response.Redirect("Q.aspx?code="+ code);
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

public class Rootobject
{
    public Table[] Table { get; set; }
    public Table1[] Table1 { get; set; }
}

public class Table
{
    public int Column1 { get; set; }
}

public class Table1
{
    public int ID { get; set; }
    public string Question { get; set; }
    public string MCQ1 { get; set; }
    public string MCQ2 { get; set; }
    public string MCQ3 { get; set; }
    public string MCQ4 { get; set; }
    public string Answer { get; set; }
    public int UserID { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsActive { get; set; }
}
