using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JudgementApp.Models
{
    public class JudgementParameter
    {
        public string UserName { get; set; }


        public string Q1_Result { get; set; }
        public string Q2_Result { get; set; }
        public string Q3_Result { get; set; }
        public string Q4_Result { get; set; }



        public string Q1_Fact { get; set; }
        public string Q1_Fiction { get; set; }
        public string Q2_Fact { get; set; }
        public string Q2_Fiction { get; set; }
        public string Q3_AM { get; set; }
        public string Q3_PM { get; set; }
        public string Q4_Before { get; set; }
        public string Q4_After { get; set; }
    }
}