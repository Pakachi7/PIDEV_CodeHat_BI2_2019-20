using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
   public  class Offre
    {
        public int OffreId { get; set;  }
        public DateTime DatePublished { get; set; }
        public DateTime  ExpiredDate { get; set; }
        public string description{ get; set; }
        public Boolean Validity { get; set; }
        public virtual ICollection<Candidate> Candidates { get; set; }




    }
}
