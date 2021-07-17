﻿using JudgementApp.Models;
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

        public ActionResult Update()
        {
           
            //SQL.ScalarQuery("Insert into CreateProblem(QuestionNo) values ('"+result+"')");
            return View("~/Views/Judgement/CreateProblem.cshtml");
        }
    }
}