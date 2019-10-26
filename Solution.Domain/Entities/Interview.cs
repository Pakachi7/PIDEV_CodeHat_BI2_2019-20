using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
   public class Interview
    {
        public int InterviewId { get; set; }
        public int Compnay_Id { get; set; }
        public int Candidat_Id { get; set; }
        public DateTime Interview_Date { get; set; }
        
        public String Interview_Location { get; set; }
        public String Interview_Type { get; set; }
       


    }
}
