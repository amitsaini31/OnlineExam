using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineExamWeb.Model
{
    public class clsQuestion
    {

        public int Id { get; set; }
        public string question { get; set; }
        public string mcq1 { get; set; }
        public string mcq2 { get; set; }
        public string mcq3 { get; set; }
        public string mcq4 { get; set; }
        public string answer { get; set; }
        public string userid { get; set; }

    }

}