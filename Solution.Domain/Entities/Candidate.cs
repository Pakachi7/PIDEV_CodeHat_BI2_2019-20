﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public enum Gender { Female, Male }
    public class Candidate 
    {
      
     
        public int CandidateId { get; set; }
     //   [Required(ErrorMessage = "this filed is required")]
     public string FirstName { get; set; }
      public string LastName { get; set; }
       public Gender Gender { get; set; }
       // [Required(ErrorMessage = "this filed is required")]
        public DateTime DateOfBirthday { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; } 
        public string ImageUrl { get; set; }



        //[Required(ErrorMessage = "this filed is required")]
        public string bio { get; set; }
        public virtual ICollection<Language> languages{ get; set; }
        public virtual ICollection<Diploma> Diplomas { get; set; }
        public virtual ICollection<Certification> Certifications { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<Interview> Interviews { get; set; }





    }
}
