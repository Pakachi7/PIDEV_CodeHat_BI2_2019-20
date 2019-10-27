using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
   public  class Question
    {
        public int QuestionId { get; set; }
        public int Quiz_Id { get; set; }
        public int Question_Value { get; set; }
        public String Question_Description { get; set; }
        public String Question_1stSuggestion { get; set; }
        public String Question_2ndSuggestion { get; set; }
        public String Question_3rdSuggestion { get; set; }
        public int Question_Correct_Answer { get; set; }

        public int QuizId { get; set; }

        [ForeignKey("QuizId")]

        public virtual Quiz Quiz { get; set; }
    }
}
