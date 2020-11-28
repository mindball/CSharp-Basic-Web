using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DTO
{
    public class ProblemWithCountSubmissionsDTO
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }
    }
}
