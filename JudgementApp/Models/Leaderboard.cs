﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JudgementApp.Models
{
    public class Leaderboard
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public int ContestAttempted { get; set; }
    }
}