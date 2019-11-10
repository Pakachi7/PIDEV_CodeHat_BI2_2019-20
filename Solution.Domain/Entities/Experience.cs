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
        public string Designation { get; set; }
        public string Description { get; set; }

        public DateTime StartDate { get; set;}

        public DateTime EndDate { get; set; }
        public int? CandidateId { get; set; }
        public virtual Candidate Candidate { get; set; }

        public override string ToString()
        {
            return Designation;
        }
    }


}
