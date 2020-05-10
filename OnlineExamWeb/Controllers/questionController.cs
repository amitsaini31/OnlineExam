using Newtonsoft.Json;
using OnlineExamWeb.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace OnlineExamWeb.Controllers
{
    [EnableCors(origins: "http://edigitalwiki.com", headers: "*", methods: "*")]
    public class questionController : ApiController
    {

        SqlConnection sqlCnn = new SqlConnection(ConfigurationManager.AppSettings["connectionstring"]);

        // POST: api/question
        public void Post([FromBody]clsQuestion value)
        {
            

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("INSERT_QUESTION", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@Question", value.question));
            cmd.Parameters.Add(new SqlParameter("@MCQ1", value.mcq1));
            cmd.Parameters.Add(new SqlParameter("@MCQ2", value.mcq2));
            cmd.Parameters.Add(new SqlParameter("@MCQ3", value.mcq3));
            cmd.Parameters.Add(new SqlParameter("@MCQ4", value.mcq4));
            cmd.Parameters.Add(new SqlParameter("@Answer", value.answer));
            cmd.Parameters.Add(new SqlParameter("@UserID", value.userid));
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
        }

        // /api/getrquestion
        [Route("api/getrquestion")]
        public string GetRQuestion()
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("FETCH_RANDOM_QUESTION", sqlCnn);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);

            return JsonConvert.SerializeObject(ds, Formatting.Indented);
            //return ds.GetXml();
        }

        // /api/getrquestion
        [Route("api/{user}/getquestionpaper")]
        public string GetQuestionPaper(string user)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("FILL_QUESTION_PAPER", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@user", user));
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            return JsonConvert.SerializeObject(ds, Formatting.Indented);
            //return ds.GetXml();
        }


        // /api/{id}/starttest
        [Route("api/starttest")]
        public string StartTest(int id)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("FILL_QUESTION_PAPER", sqlCnn);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            return JsonConvert.SerializeObject(ds, Formatting.Indented);
            //return ds.GetXml();
        }

        // /api/{id}/starttest
        [Route("api/{code}/initialload")]
        public string InitialLoad(string code)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("FILL_INITIAL_LOAD", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@code", code));
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            return JsonConvert.SerializeObject(ds, Formatting.Indented);
            //return ds.GetXml();
        }

        // /api/{code}/{id}/{answer}/{user}/questionattempt
        [Route("api/{code}/{id}/{answer}/{user}/questionattempt")]
        public string Questionattempt(string code, string id, string answer, string user)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("INSERT_USER_ATTEMPT", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@QuestionPaperCode", code));
            cmd.Parameters.Add(new SqlParameter("@QuestionID", id));
            cmd.Parameters.Add(new SqlParameter("@Answer", answer));
            cmd.Parameters.Add(new SqlParameter("@UserID", user));
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            return JsonConvert.SerializeObject(ds, Formatting.Indented);
            //return ds.GetXml();
        }

        // /api/{id}/nextquestion
        [Route("api/{code}/{id}/{prevnext}/{currentquestionid}/question")]
        public string nextquestion(string id, string code, string prevnext, string currentquestionid)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("FETCH_QUESTION", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@code", code));
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.Parameters.Add(new SqlParameter("@prevnext", prevnext));
            cmd.Parameters.Add(new SqlParameter("@currentquestionid", currentquestionid));

            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            return JsonConvert.SerializeObject(ds, Formatting.Indented);
            //return ds.GetXml();
        }

        // /api/{id}/getquestion
        [Route("api/{code}/{id}/{user}/getquestion")]
        public string getquestion(string id, string code, string user)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("FETCH_QUESTION1", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@code", code));
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.Parameters.Add(new SqlParameter("@user", user));

            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            return JsonConvert.SerializeObject(ds, Formatting.Indented);
            //return ds.GetXml();
        }

        // /api/{code}/deletequestionpaper
        [Route("api/{code}/{user}/deletequestionpaper")]
        public string deletequestionpaper(string code, string user)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("DELETE_QUESTION_PAPER", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@code", code));
            cmd.Parameters.Add(new SqlParameter("@user", user));

            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            return JsonConvert.SerializeObject(ds, Formatting.Indented);
            //return ds.GetXml();
        }

        // /api/{code}/deletequestionpaper
        [Route("api/{code}/questionsbycode")]
        public string questionsbycode(string code)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("FETCH_QUESTION_BYCODE", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@code", code));

            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            return JsonConvert.SerializeObject(ds, Formatting.Indented);
            //return ds.GetXml();
        }


        // /api/{code}/deletequestionpaper
        [Route("api/{code}/{user}/starttest")]
        public string starttest(string code,string user)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("START_TEST", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@code", code));
            cmd.Parameters.Add(new SqlParameter("@user", user));

            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            return JsonConvert.SerializeObject(ds, Formatting.Indented);
            //return ds.GetXml();
        }


        // /api/{user}/getresult
        [Route("api/{user}/getresult")]
        public string getresult(string user)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("FILL_RESULT", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@user", user));

            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            return JsonConvert.SerializeObject(ds, Formatting.Indented);
            //return ds.GetXml();
        }

        // /api/{user}/getresult
        [Route("api/{user}/{code}/getuserresult")]
        public string getuserresult(string user, string code)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("FILL_USER_RESULT", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@user", user));
            cmd.Parameters.Add(new SqlParameter("@code", code));

            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            return JsonConvert.SerializeObject(ds, Formatting.Indented);
            //return ds.GetXml();
        }

        // /api/{user}/getresult
        [Route("api/getcategory")]
        public string getcategory()
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("FILL_CATEGORY", sqlCnn);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            return JsonConvert.SerializeObject(ds, Formatting.Indented);
            //return ds.GetXml();
        }

        // /api/{user}/getresult
        [Route("api/{id}/getcategory")]
        public string getcategory(string id)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("FETCH_CATEGORY", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            return JsonConvert.SerializeObject(ds, Formatting.Indented);
            //return ds.GetXml();
        }

        // /api/{user}/getbatch
        [Route("api/{user}/getbatch")]
        public string getbatch(string user)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("FILL_BATCH", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@user", user));
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            return JsonConvert.SerializeObject(ds, Formatting.Indented);
            //return ds.GetXml();
        }

        // /api/{user}/getresult
        [Route("api/{user}/{id}/getbatch")]
        public string getbatch(string id, string user)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("FETCH_BATCH", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.Parameters.Add(new SqlParameter("@user", user));
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            return JsonConvert.SerializeObject(ds, Formatting.Indented);
            //return ds.GetXml();
        }

        // /api/getinstitutiondashboard
        [Route("api/{id}/getinstitutiondashboard")]
        public string getinstitutiondashboard(string id)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("FILL_INSTITUTION_DASHBOARD", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            return JsonConvert.SerializeObject(ds, Formatting.Indented);
            //return ds.GetXml();
        }

        // /api/getinstitutiondashboard
        [Route("api/{user}/filluserquestion")]
        public string filluserquestion(string user)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("FILL_USER_QUESTIONS", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@user", user));
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            return JsonConvert.SerializeObject(ds, Formatting.Indented);
            //return ds.GetXml();
        }

        // /api/getuserquestionpaper
        [Route("api/{user}/getuserquestionpaper")]
        public string getuserquestionpaper(string user)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("FILL_USER_QUESTION_PAPER", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@user", user));
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            return JsonConvert.SerializeObject(ds, Formatting.Indented);
            //return ds.GetXml();
        }

        // /api/getuserquestionpaper
        [Route("api/{user}/getallquestionpaper")]
        public string getallquestionpaper(string user)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("FILL_PUBLIC_QUESTION_PAPER", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@user", user));
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            return JsonConvert.SerializeObject(ds, Formatting.Indented);
            //return ds.GetXml();
        }


        // /api/getuserquestionpaper
        [Route("api/{user}/{code}/subscribe")]
        public string subscribe(string user, string code)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("INSERT_USER_QUESTION_PAPER", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@UserID", user));
            cmd.Parameters.Add(new SqlParameter("@code", code));
            cmd.Parameters.Add(new SqlParameter("@user", user));
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            return JsonConvert.SerializeObject(ds, Formatting.Indented);
            //return ds.GetXml();
        }

        // /api/getuserquestionpaper
        [Route("api/{user}/{code}/removetest")]
        public string removetest(string user, string code)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("DELETE_USER_QUESTION_PAPER", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@code", code));
            cmd.Parameters.Add(new SqlParameter("@user", user));
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            return JsonConvert.SerializeObject(ds, Formatting.Indented);
            //return ds.GetXml();
        }

        // /api/getuserquestionpaper
        [Route("api/{id}/{user}/connectuser")]
        public string connectuser(string id, string user)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("CONNECT_USER", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@id", id));
            cmd.Parameters.Add(new SqlParameter("@user", user));
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            return JsonConvert.SerializeObject(ds, Formatting.Indented);
            //return ds.GetXml();
        }

        // /api/getrquestion
        [Route("api/getrsquestion")]
        public string GetRSQuestion()
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("FETCH_RANDOM_SAMPLE_QUESTION", sqlCnn);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);

            return JsonConvert.SerializeObject(ds, Formatting.Indented);
            //return ds.GetXml();
        }

        // /api/adduserbatch
        [Route("api/{batchid}/{userid}/{user}/adduserbatch")]
        public void adduserbatch(string batchid, string userid, string user)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("INSERT_USER_BATCH", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@batchid", batchid));
            cmd.Parameters.Add(new SqlParameter("@userid", userid));
            cmd.Parameters.Add(new SqlParameter("@user", user));
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
        }

        

        // /api/filluser
        [Route("api/{batchid}/{user}/getuserbatch")]
        public string getuserbatch(string batchid, string user)
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("FILL_USER_BATCH", sqlCnn);
            cmd.Parameters.Add(new SqlParameter("@batchid", batchid));
            cmd.Parameters.Add(new SqlParameter("@user", user));
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            return JsonConvert.SerializeObject(ds, Formatting.Indented);
        }

        // /api/getrquestion
        [Route("api/mgetrsquestion")]
        [HttpGet]
        public clsQuestion MGetRSQuestion()
        {

            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();

            cmd = new SqlCommand("FETCH_RANDOM_SAMPLE_QUESTION", sqlCnn);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);

            //List<clsQuestion> lstques = new List<clsQuestion>();

            clsQuestion ques = new clsQuestion();
            ques.question = ds.Tables[0].Rows[0]["Question"].ToString();
            ques.mcq1 = ds.Tables[0].Rows[0]["A"].ToString();
            ques.mcq2 = ds.Tables[0].Rows[0]["B"].ToString();
            ques.mcq3 = ds.Tables[0].Rows[0]["C"].ToString();
            ques.mcq4 = ds.Tables[0].Rows[0]["D"].ToString();
            ques.answer = ds.Tables[0].Rows[0]["Answer"].ToString();
            //ques.answer = "0";

            return ques;
        }
    }
}
