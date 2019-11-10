using Service.Pattern;
using Solution.Data.Infrastructure;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
    public class CandidateService : Service<Candidate>, ICandidatService
    {
        static IDataBaseFactory factory = new DataBaseFactory();

        static UnitOfWork UTK = new UnitOfWork(factory);
        public CandidateService():base(UTK)
        {
            

        }
        public IEnumerable<Candidate> GetCandidateByCertification(int IdCertificat)
        {
            throw new NotImplementedException();

           // return GetMany(f => f.Certifications. == IdCertificat) ;
        }

        public IEnumerable<Candidate> GetCandidateByDiploma(int IdExperience)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Candidate> GetCandidateByExperience(int IdExperience)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Candidate> GetCandidateByLanguage(int IdLanguage)
        {
            throw new NotImplementedException();
        }

        public List<Candidate> GetCandidatesByCriteria(string criteria)
        {
            List<Candidate> toReturn = GetMany(c => c.FirstName.Contains(criteria) || c.LastName.Contains(criteria)).ToList();
            if(toReturn.Count!=0)
                return toReturn;
            List<Candidate> second = GetMany().ToList();
            for (int i = 0; i < second.Count; i++)
            {
                for(int j = 0;j<second.ElementAt(i).Skills.Count;j++)
                {
                    if(second.ElementAt(i).Skills.ElementAt(j).Designation.Contains(criteria))
                    {
                        if (!toReturn.Contains(second.ElementAt(i)))
                        toReturn.Add(second.ElementAt(i));
                    }
                }
                if (toReturn.Count != 0)
                    return toReturn;
                for (int j = 0; j < second.ElementAt(i).Experiences.Count; j++)
                {
                    if (second.ElementAt(i).Experiences.ElementAt(j).Designation.Contains(criteria))
                    {
                        if (!toReturn.Contains(second.ElementAt(i)))
                            toReturn.Add(second.ElementAt(i));
                    }
                }
                if (toReturn.Count != 0)
                    return toReturn;
            }
            return toReturn;
        }
    }
}
