using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Claim
    {
        public int ClaimId { get; set; }
        public User UserId { get; set; }

        public string Object_claim { get; set; }
        public string Content_claim { get; set; }
        public string Type_claim { get; set; }
        public DateTime Date_claim { get; set; }
        public DateTime TreatmentDate_claim { get; set; }
        public string State_claim { get; set; }
    }
}
