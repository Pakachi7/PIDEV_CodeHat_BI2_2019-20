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
    }
}
