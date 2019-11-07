using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Experience
    {
        public int ExperienceId { get; set; }
        public int Nbr { get; set; }
        public string field { get; set; }
        public int CandidateId { get; set; }
        public virtual Candidate Candidate { get; set; }


    }
}
