using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DTO
{
    public class ProblemWithSubmisionsDTO
    {
        public string Name { get; set; }

        public IEnumerable<SubmissionDTO> Submissions { get; set; }
    }
}
