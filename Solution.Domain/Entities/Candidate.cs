using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Candidate :User
    {
      
     
        public int CandidateId { get; set; }
     //   [Required(ErrorMessage = "this filed is required")]
        public string sex;
       // [Required(ErrorMessage = "this filed is required")]
        public string birthday;
        //[Required(ErrorMessage = "this filed is required")]
        public string bio;
        public virtual ICollection<Language> languages{ get; set; }
        public virtual ICollection<Diploma> Diplomas { get; set; }
        public virtual ICollection<Certification> Certifications { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }
        public virtual ICollection<Offre> Offres { get; set; }
        public virtual ICollection<Company> Companies { get; set; }






    }
}
