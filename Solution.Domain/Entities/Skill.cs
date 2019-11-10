using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string Designation { get; set; }
        public float rating { get; set; }
        
        public int? CandidateId { get; set; }
        public virtual Candidate Candidate { get; set; }


    }
}
