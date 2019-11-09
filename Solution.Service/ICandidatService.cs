using Service.Pattern;
using Solution.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
    public interface ICandidatService : IService<Candidate>
    {

        IEnumerable<Candidate> GetCandidateByExperience(int IdExperience);
        IEnumerable<Candidate> GetCandidateByLanguage(int IdLanguage);
        IEnumerable<Candidate> GetCandidateByDiploma(int IdExperience);
        IEnumerable<Candidate> GetCandidateByCertification(int IdExperience);

        List<Candidate> GetCandidatesByCriteria(string criteria);


    }
}