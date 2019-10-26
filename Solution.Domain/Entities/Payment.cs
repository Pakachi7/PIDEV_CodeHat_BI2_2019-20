using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public User UserId { get; set; }
        public double Amount_payment { get; set; }
        public DateTime Payment_date { get; set; }
        public virtual ICollection<Candidate> Candidates { get; set; }
    }
}
