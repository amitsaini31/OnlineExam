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
    public partial class QP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            hdnapi.Value = Convert.ToString(Application["api"]);

            if (Session["user"] != null)
            {
                DataSet ds = (DataSet)Session["user"];
                string user = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                hdnu.Value = Convert.ToString(ds.Tables[0].Rows[0]["UserID"]);
                //ausername.InnerHtml = user;
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

            ViewState["QuestionPaperCode"] = Convert.ToString(Session["QuestionPaperCode"]);

            if (!IsPostBack)
            {
                LoadCategory();

                if (Request.QueryString["code"] == null)
                {
                    ViewState["QuestionPaperCode"] = Convert.ToString(Request.QueryString["code"]);
                }
                else
                {
                    ViewState["QuestionPaperCode"] = Convert.ToString(Request.QueryString["code"]);
                }
                if (Request.QueryString["dcode"] != null)
                {
                    string code = Convert.ToString(Request.QueryString["dcode"]);
                    string user = "";
                    if (Session["user"] != null)
                    {
                        DataSet ds = (DataSet)Session["user"];
                        user = Convert.ToString(ds.Tables[0].Rows[0]["UserID"]);
                    }

                    Methods methods = new Methods();
                    methods.DELETE_QUESTION_PAPER(code, user);
                }

                if (Request.QueryString["pcode"] != null)
                {
                    string code = Convert.ToString(Request.QueryString["pcode"]);
                    string user = "";
                    if (Session["user"] != null)
                    {
                        DataSet ds = (DataSet)Session["user"];
                        user = Convert.ToString(ds.Tables[0].Rows[0]["UserID"]);
                    }
                    Methods methods = new Methods();
                    methods.PUBLISH_QUESTION_PAPER(code);
                }


                if (Request.QueryString["pubcode"] != null)
                {
                    string code = Convert.ToString(Request.QueryString["pubcode"]);
                    string user = "";
                    if (Session["user"] != null)
                    {
                        DataSet ds = (DataSet)Session["user"];
                        user = Convert.ToString(ds.Tables[0].Rows[0]["UserID"]);
                    }
                    Methods methods = new Methods();
                    methods.PUBLIC_QUESTION_PAPER(code);
                }

                string QuestionPaperCode = Convert.ToString(ViewState["QuestionPaperCode"]);

                dvAdd.Visible = false;
                dvView.Visible = true;


                if (Request.QueryString["ecode"] != null)
                {
                    string code = Convert.ToString(Request.QueryString["ecode"]);
                    string user = "";
                    if (Session["user"] != null)
                    {
                        DataSet ds = (DataSet)Session["user"];
                        user = Convert.ToString(ds.Tables[0].Rows[0]["UserID"]);
                    }
                    Methods methods = new Methods();

                    DataSet ds1 = methods.FETCH_QUESTION_PAPER(code, user);

                    txtQuestionPaperCode.Text = lblQuestionPaperCode.Text = code;
                    txtQuestionPaperCode.Visible = false;
                    lblQuestionPaperCode.Visible = true;
                    hdnid.Value = Convert.ToString(ds1.Tables[0].Rows[0]["ID"]);
                    txtTitle.Text = Convert.ToString(ds1.Tables[0].Rows[0]["Title"]);
                    txtHiddenTitle.Text = Convert.ToString(ds1.Tables[0].Rows[0]["HiddenTitle"]);
                    txtQuestionCount.Text = Convert.ToString(ds1.Tables[0].Rows[0]["QuestionCount"]);
                    txtGeneralInstructions.Value = Convert.ToString(ds1.Tables[0].Rows[0]["GeneralInstructions"]);
                    ddlCategory.SelectedValue = Convert.ToString(ds1.Tables[0].Rows[0]["CategoryID"]);
                    dvAdd.Visible = true;
                    dvView.Visible = false;

                }
            }
            else
            {
                //txtQuestionPaperCode.Text = "";
                //lblQuestionPaperCode.Text = "";
                //txtQuestionPaperCode.Visible = true;
                //lblQuestionPaperCode.Visible = false;
                //txtTitle.Text = "";
                //txtHiddenTitle.Text = "";
                //txtQuestionCount.Text = "0";
                //txtGeneralInstructions.Value = "";
                //hdnid.Value = "0";

                dvView.Visible = true;
                dvAdd.Visible = false;
                Session["QuestionPaperCode"] = null;
            }
        }

        public void LoadCategory()
        {
            Methods methods = new Methods();
            DataSet ds = methods.FILL_CATEGORY();

            DataRow toInsert = ds.Tables[0].NewRow();
            toInsert[0] = 0;
            toInsert[1] = "--Select--";
            // insert in the desired place
            ds.Tables[0].Rows.InsertAt(toInsert, 0);

            ddlCategory.DataSource = ds.Tables[0];
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "ID";
            ddlCategory.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {


                string code = txtQuestionPaperCode.Text;
                string title = txtTitle.Text;
                string hiddentitle = txtHiddenTitle.Text;
                string questioncount = txtQuestionCount.Text;
                string generalinstructions = txtGeneralInstructions.Value;
                string category = ddlCategory.SelectedValue;

                string user = "";
                if (Session["user"] != null)
                {
                    DataSet ds1 = (DataSet)Session["user"];
                    user = Convert.ToString(ds1.Tables[0].Rows[0]["UserID"]);
                }


                Methods method = new Methods();
                method.INSERT_QUESTION_PAPER(hdnid.Value, code, title, hiddentitle, questioncount, generalinstructions, category, user);


                //Session["QuestionPaperCode"] = code;
                //Response.Redirect("Question.aspx");

            }
            catch (Exception ex)
            {

            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            txtQuestionPaperCode.Text = "";
            txtQuestionPaperCode.Enabled = true;
            txtQuestionPaperCode.Visible = true;
            lblQuestionPaperCode.Text = "0";
            lblQuestionPaperCode.Visible = false;
            txtTitle.Text = "";
            txtHiddenTitle.Text = "";
            txtQuestionCount.Text = "0";
            txtGeneralInstructions.Value = "";
            hdnid.Value = "0";

            dvAdd.Visible = true;
            dvView.Visible = false;
            Session["QuestionPaperCode"] = null;
        }
    }
}