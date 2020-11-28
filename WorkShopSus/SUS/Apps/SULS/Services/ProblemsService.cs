namespace Services
{
    using System.Collections.Generic;
    using System.Linq;

    using Data;
    using Models;
    using System;
    using Services.DTO;

    public class ProblemsService : IProblemsService
    {
        private SULSContext db;
        public ProblemsService(SULSContext db)
        {
            this.db = db;
        }

        public void Create(string name, ushort points)
        {
            var problem = new Problem { Name = name, Points = points };
            this.db.Problems.Add(problem);
            this.db.SaveChanges();
        }

        public IEnumerable<ProblemWithCountSubmissionsDTO> GetAll()
        {
            var problems = this.db.Problems.Select(x => new ProblemWithCountSubmissionsDTO
            {
                Id = x.Id,
                Name = x.Name,
                Count = x.Submissions.Count(),
            }).ToList();

            return problems;
        }

        public ProblemWithSubmisionsDTO GetById(string id)
        {
            return this.db.Problems.Where(x => x.Id == id)
                .Select(x => new ProblemWithSubmisionsDTO
                {
                    Name = x.Name,
                    Submissions = x.Submissions.Select(s => new SubmissionDTO
                    {
                        CreatedOn = s.CreatedOn,
                        SubmissionId = s.Id,
                        AchievedResult = s.AchievedResult,
                        Username = s.User.Username,
                        MaxPoints = x.Points,
                    })
                }).FirstOrDefault();
        }

        public string GetNameById(string id)
        {
            return this.db.Problems
                .Where(x => x.Id == id)
                .Select(x => x.Name)
                .FirstOrDefault();
        }
    }
}
