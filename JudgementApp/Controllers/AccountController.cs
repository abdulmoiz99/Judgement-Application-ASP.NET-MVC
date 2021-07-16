using JudgementApp.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JudgementApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult Users(Account account)
        //{
        //    string con = @"Data Source=ABDUL-MOIZ\SQLEXPRESS;Initial Catalog=QuizAppAsp;Integrated Security=True;Pooling=False";
        //    String sql = "SELECT * FROM Login";
        //    SqlCommand cmd = new SqlCommand(sql, SQL.Con);

        //    var model = new List<Account>();
        //    if (SQL.Con.State == System.Data.ConnectionState.Open)
        //    {
        //        SQL.Con.Close();
        //    }
        //    SQL.Con.Open();
        //    SqlDataReader rdr = cmd.ExecuteReader();
        //    while (rdr.Read())
        //    {
        //        var users = new Account();
        //        users.FirstName = rdr["LoginFirstName"].ToString();
        //        users.LastName = rdr["LoginLastName"].ToString();
        //        users.Email = rdr["LoginEmail"].ToString();

        //        model.Add(users);
        //    }
        //    return View(model);
        //}
    }
}