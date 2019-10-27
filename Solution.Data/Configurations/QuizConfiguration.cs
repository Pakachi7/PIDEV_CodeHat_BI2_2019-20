using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Data.Configurations
{
    class QuizConfiguration : EntityTypeConfiguration<Quiz>
    {
        public QuizConfiguration()
        {
            HasMany(quiz => quiz.Questions).
                          WithRequired(question => question.Quiz).//prop nav
                          HasForeignKey(question => question.QuizId).//prop nav
                          WillCascadeOnDelete(false);
        }
       
    }
}
