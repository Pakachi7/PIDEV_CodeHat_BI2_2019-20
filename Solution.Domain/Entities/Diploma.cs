using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Diploma
    {
       public int DiplomaId { get; set; }
        public string DiplomaName { get; set; }
        public string DiplomaSpeciality  { get; set; }
        public DateTime ObtainingDate { get; set; }
        public string DiplomaUniversity { get; set; }

        public int? CandidateId { get; set; }
        public virtual Candidate Candidate { get; set; }

    }
}
