using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using OnlineExamWeb.BusinessLogics;
using System.Data;

namespace OnlineExamWeb
{
    public partial class SendNotification : System.Web.UI.Page
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

            if(!IsPostBack)
            {
                txtdata.Value = "{\r\n    \"to\":\"/topics/AMIT_SAINI\",\r\n    \"data\": {\r\n        \"ImageUrl\": \"https://images.pexels.com/photos/46710/pexels-photo-46710.jpeg\",\r\n        \"key2\": \"Hello Postman\"\r\n    },\r\n    \"notification\": {\r\n        \"title\": \"Are you free Amit?\",\r\n        \"body\": \"Are you there?\",\r\n        \"image\": \"https://images.pexels.com/photos/2895411/pexels-photo-2895411.jpeg\"\r\n    }\r\n}";
            }
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {

            //FCMNotifier string SERVER_API_KEY = "AAAAB-edTNg:APA91bEdyRxzasUpGGcbXJfq1dJhkeQOPj3aOjQ_ir5XIn54Q4MRqqHuYAyX_GUlvE1_3lSplOoIMCLRwPme7yt-4y_sl6muSXmT01qi-vAN_t7_a5K4ne75IBrIbeotsQtYe6AhiE0R";
            string SERVER_API_KEY = "AAAAgotBch0:APA91bG3WSAV-1rmO0wnHEB438rRsUcdWWpjdri1a2Hetu5P1GjvA2RFj3ez_DnDgUj12T50UOp3a6KJ-X9dORzs8VapqP7GCnyP5Zynfk1-Elv52vgTcoxUe3Fj4_QBVm_1upWsbKFn";
            var SENDER_ID = "33950616792";
           
            WebRequest tRequest;
            tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "POST";
            tRequest.ContentType = "application/json";
            tRequest.Headers.Add(string.Format("Authorization: key={0}", SERVER_API_KEY));

            tRequest.Headers.Add(string.Format("Sender: id={0}", SENDER_ID));

            string postData = txtdata.Value;
            Console.WriteLine(postData);
            Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            tRequest.ContentLength = byteArray.Length;

            Stream dataStream = tRequest.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse tResponse = tRequest.GetResponse();

            dataStream = tResponse.GetResponseStream();

            StreamReader tReader = new StreamReader(dataStream);

            String sResponseFromServer = tReader.ReadToEnd();


            tReader.Close();
            dataStream.Close();
            tResponse.Close();
            //return sResponseFromServer;
        }

       
    }
}