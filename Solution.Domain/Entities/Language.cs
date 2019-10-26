using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Language
    {
        [Key]
        public int LanguageId { get; set; }
        public string languageName { get; set; }
    public int Nbr { get; set; }
    public string Level  { get; set; }
        public virtual ICollection<Candidate>Candidates { get; set; }


    }
}
