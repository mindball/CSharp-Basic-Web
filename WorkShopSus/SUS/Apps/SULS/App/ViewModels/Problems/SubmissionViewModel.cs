﻿using System;
using System.Collections.Generic;
using System.Text;

namespace App.ViewModels.Problems
{
    public class SubmissionViewModel
    {
        public string Username { get; set; }

        public string SubmissionId { get; set; }

        public DateTime CreatedOn { get; set; }

        public int AchievedResult { get; set; }

        public int MaxPoints { get; set; }

        public int Percentage => (int)Math.Round(this.AchievedResult * 100.0M / this.MaxPoints);
    }
}
