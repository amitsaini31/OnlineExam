using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineExamWeb
{
    public partial class VisitorHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userid = "";
            if (Session["user"] != null)
            {
                DataSet ds = (DataSet)Session["user"];
                string user = Convert.ToString(ds.Tables[0].Rows[0]["Email"]);
                userid = Convert.ToString(ds.Tables[0].Rows[0]["UserID"]);

                ausername.InnerHtml = user;
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

            string api = ConfigurationManager.AppSettings["api"];
            WebClient w = new WebClient();
            var json_data = w.DownloadString(api+ "/" + userid + "/getuserquestionpaper");
            var data1 = JsonConvert.DeserializeObject(json_data);
            var data2 = JsonConvert.DeserializeObject<Rootobject>(data1.ToString());

            StringBuilder sb = new StringBuilder();
            foreach (var item in data2.Table)
            {
                sb.Append("<tr><td>" + item.QuestionPaperCode + "</td><td>" + item.QuestionPaperCode + "</td><td><a class='btn btn-primary' href='Test.aspx?code=" + item.QuestionPaperCode + "'>Start</a></td></tr>");
            }
            tBody.InnerHtml = sb.ToString();

           
        }

    }

    public class Rootobject
    {
        public QPaper[] Table { get; set; }
    }

    public class QPaper
    {
        public int ID { get; set; }
        public string QuestionPaperCode { get; set; }
        public string Title { get; set; }
        public string HiddenTitle { get; set; }
        public int QuestionCount { get; set; }
        public int UserID { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDelete { get; set; }
    }




}