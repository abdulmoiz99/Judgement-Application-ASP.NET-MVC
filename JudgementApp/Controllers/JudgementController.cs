using JudgementApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
        public ActionResult Leaderboard()
        {
            var leaderboard = new List<Leaderboard>();

            var results = Main.GetDataTable("select * from Judgement");

            foreach (DataRow Item in results.Rows)
            {
                var row = new Leaderboard();
                row.Id = Convert.ToInt32(Item["ID"]);
                row.Username = Item["Name"].ToString();
                row.ContestAttempted = Convert.ToInt32(Item["ContestAttempted"]);
                leaderboard.Add(row);
            }

            return View(leaderboard);
        }
        public ActionResult saveJudgement(JudgementParameter result)
        {
            if (Main.CheckUser(result.UserName))
            {

                SQL.NonScalarQuery("update Judgement set Q1 ='" + result.Q1_Result + "',Q2 = '" + result.Q2_Result + "',Q3 = '" + result.Q3_Result + "',Q4 = '" + result.Q4_Result + "', ContestAttempted = ContestAttempted + 1 where Name = '" + result.UserName + "'");
            }
            else
            {
                SQL.NonScalarQuery("Insert into Judgement (Name                     ,Q1                        ,Q2                        ,Q3                        ,Q4                         ,contestAttempted)" +
                                                 " VALUES ('" + result.UserName + "','" + result.Q1_Result + "','" + result.Q2_Result + "','" + result.Q3_Result + "','" + result.Q4_Result + "' , 1)");
            }
            return View("~/Views/Judgement/ResponseSubmitted.cshtml");
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