using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Quiz
    {
        public int QuizId { get; set; }
        public int Compnay_Id { get; set; }
        public int Candidat_Id { get; set; }
        public int Max_Score { get; set; }
        public int Success_Score { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

    }
}
