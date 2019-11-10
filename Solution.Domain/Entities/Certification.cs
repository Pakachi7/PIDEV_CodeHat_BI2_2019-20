using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Certification
    {
        public int CertificationId { get; set; }
        public string Name { get; set; }
        public int Nbr { get; set; }
        public virtual ICollection<Candidate> Candidates { get; set; }

    }
}
