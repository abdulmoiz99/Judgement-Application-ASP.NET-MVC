using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JudgementApp
{
    public class Main
    {
        public static string GetParameter(int questionNo, string ParameterNo)
        {
            return SQL.ScalarQuery("select " + ParameterNo + " from CreateProblem where questionNo = " + questionNo + "");
        }
        public static bool CheckUser(string name)
        {
            string check = "";
            check = SQL.ScalarQuery("SELECT CASE WHEN EXISTS (SELECT TOP 1 * FROM Judgement  WHERE Name = '" + name + "' ) THEN CAST (1 AS BIT) ELSE CAST (0 AS BIT) END");




            if (string.Equals("True", check))
            {
                return true;

            }



            else return false;


        }
    }
}