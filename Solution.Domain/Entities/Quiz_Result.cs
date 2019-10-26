using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
   public  class Quiz_Result
    {
        public int Quiz_Result_Id { get; set; }
        public int Quiz_Id { get; set; }
        public int Candidat_Id { get; set; }
        public int Quiz_Result_Score { get; set; }
        public String Quiz_Result_Status { get; set; }
    }
}
