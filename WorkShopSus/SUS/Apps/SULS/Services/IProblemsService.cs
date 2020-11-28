using Services.DTO;
using System.Collections.Generic;

namespace Services
{
    public interface IProblemsService
    {
        void Create(string name, ushort points);

        IEnumerable<ProblemWithCountSubmissionsDTO> GetAll();

        string GetNameById(string id);

        ProblemWithSubmisionsDTO GetById(string id);
    }
}
