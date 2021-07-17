using JudgementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace JudgementApp.Controllers
{
    public class JudgementController : Controller
    {
        // GET: Judgement
        public ActionResult Index()
        {
            //var model = new Data();
            //model.Q1_P1 = Main.GetParameter(1, "p1");
            return View();
        }
        public ActionResult CreateProblem(Data data)
        {
            var model = new List<Data>();
            var url = "http://oatsreportable.finra.org/OATSReportableSecurities-SOD.txt";
            var results = (new WebClient()).DownloadString(url);

            var Lines = results.Split('\n');
            int id = 0;
            foreach (var line in Lines)
            {
                var data1 = new Data();
                data1.SymbolName = line.Split('|')[0];
                data1.Id = id++;
                model.Add(data1);
            }
            return View(model);

        }

        public ActionResult saveJudgement(JudgementParameter parameter)
        {
            string Q1 = "", Q2 = "", Q3 = "", Q4 = "";
            //Question 1
            if (parameter.Q1_Fact == "on")
                Q1 = "Fact";
            else if (parameter.Q1_Fiction == "on")
                Q1 = "Fiction";

            //Question 2
            if (parameter.Q2_Fact == "on")
                Q2 = "Fact";
            else if (parameter.Q2_Fiction == "on")
                Q2 = "Fiction";
            //Question 3
            if (parameter.Q3_AM == "on")
                Q3 = "AM";
            else if (parameter.Q3_PM == "on")
                Q3 = "PM";
            //Question 4
            if (parameter.Q4_Before == "on")
                Q4 = "Before";
            else if (parameter.Q4_After == "on")
                Q4 = "After";

            if (Main.CheckUser(parameter.UserName))
            {
                SQL.ScalarQuery("update Judgement set Q1 = '" + Q1 + "'," +
                                                    " Q2 = '" + Q2 + "'" +
                                                    " Q3 = '" + Q3 + "'" +
                                                    " Q4 = '" + Q4 + "'" +
                                                    " where name = '" + parameter.UserName + "'");
            }
            else
            {
                SQL.ScalarQuery("Insert into Judgement (Name                        ,Q1          ,Q2          ,Q3         ,Q4            ,contestAttempted)" +
                                              " VALUES ('" + parameter.UserName + "','" + Q1 + "','" + Q2 + "','" + Q3 + "','" + Q4 + "' , 1)");
            }
            return View();
        }
        public ActionResult Update(Data parameter)
        {
            SQL.ScalarQuery("Update CreateProblem  set p1 = '" + parameter.Q1_P1 + "' where QuestionNo = 1");
            SQL.ScalarQuery("Update CreateProblem  set p2 = '" + parameter.Q1_P2 + "' where QuestionNo = 1");
            SQL.ScalarQuery("Update CreateProblem  set p3 = '" + parameter.Q1_P3 + "' where QuestionNo = 1");
            SQL.ScalarQuery("Update CreateProblem  set p1 = '" + parameter.Q2_P1 + "' where QuestionNo = 2");
            SQL.ScalarQuery("Update CreateProblem  set p2 = '" + parameter.Q2_P2 + "' where QuestionNo = 2");
            SQL.ScalarQuery("Update CreateProblem  set p3 = '" + parameter.Q2_P3 + "' where QuestionNo = 2");
            SQL.ScalarQuery("Update CreateProblem  set p4 = '" + parameter.Q2_P4 + "' where QuestionNo = 2");
            SQL.ScalarQuery("Update CreateProblem  set p1 = '" + parameter.Q3_P1 + "' where QuestionNo = 3");
            SQL.ScalarQuery("Update CreateProblem  set p1 = '" + parameter.Q4_P1 + "' where QuestionNo = 4");
            SQL.ScalarQuery("Update CreateProblem  set p2 = '" + parameter.Q4_P2 + "' where QuestionNo = 4");
            return View("~/Views/Judgement/Success.cshtml");
        }
    }
}