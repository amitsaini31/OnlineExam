using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OnlineExamWeb.BusinessLogics;
using System.Data;
using System.Web.Services;
using System.Data.SqlClient;
using System.Configuration;

namespace OnlineExamWeb
{
    public partial class UserBatchMap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            hdnapi.Value = Convert.ToString(Application["api"]);
            string userid = "";
            if (Session["user"] != null)
            {
                DataSet ds1 = (DataSet)Session["user"];
                hdnu.Value = userid = Convert.ToString(ds1.Tables[0].Rows[0]["UserID"]);
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

            dvView.Visible = true;
            dvAdd.Visible = false;


            if (!IsPostBack)
            {
                LoadBatches(userid);
            }

            if (Request.QueryString["code"] != null)
            {
                ViewState["id"] = Convert.ToString(Request.QueryString["code"]);

                ddlBatch.SelectedValue = Convert.ToString(ViewState["id"]);
                ddlBatch1.SelectedValue = Convert.ToString(ViewState["id"]);
            }
            


        }

        public void LoadBatches(string userid)
        {

            Methods methods = new Methods();
            DataSet ds = methods.FILL_BATCH(userid);

            DataRow dr = ds.Tables[0].NewRow();
            dr[0] = "0";
            dr[1] = "--Select--";
            ds.Tables[0].Rows.InsertAt(dr, 0);

            ddlBatch.DataSource = ds.Tables[0];
            ddlBatch.DataMember = "ID";
            ddlBatch.DataValueField = "ID";
            ddlBatch.DataTextField = "BatchName";

            ddlBatch.DataBind();

            ddlBatch1.DataSource = ds.Tables[0];
            ddlBatch1.DataMember = "ID";
            ddlBatch1.DataValueField = "ID";
            ddlBatch1.DataTextField = "BatchName";

            ddlBatch1.DataBind();

        }


        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            Methods methods = new Methods();
            methods.INSERT_USER_BATCH(ddlBatch.SelectedValue, hdnbatchuser.Value, hdnu.Value);
            ddlBatch.SelectedValue = "0";
            txtusername.Text = "";
        }

        protected void btnAdd_ServerClick(object sender, EventArgs e)
        {
            ddlBatch.SelectedValue = ddlBatch1.SelectedValue;
            dvView.Visible = false;
            dvAdd.Visible = true;
        }


        [WebMethod]
        public static string[] GetUsers(string prefix)
        {
            List<string> customers = new List<string>();

            DataSet ds = new DataSet();



            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.AppSettings["connectionstring"];

                //cmd.CommandText = "select Email + '('+ UserID +')' as Email, UserID from USER_TBL where Email like @SearchText + '%' or UserID like @SearchText + '%'";
                //cmd.Parameters.AddWithValue("@SearchText", prefix);
                //cmd.Connection = conn;
                //conn.Open();
                //using (SqlDataReader sdr = cmd.ExecuteReader())
                //{
                //    while (sdr.Read())
                //    {

                //    }
                //}
                SqlCommand cmd = new SqlCommand();
                cmd = new SqlCommand("FILL_USER", conn);
                cmd.Parameters.Add(new SqlParameter("@keyword", prefix));
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);

                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    string email = item[0].ToString();
                    string userid = item[1].ToString();

                    customers.Add(string.Format("{0}-{1}", email, userid));
                }
                conn.Close();

            }
            return customers.ToArray();
        }

    }
}