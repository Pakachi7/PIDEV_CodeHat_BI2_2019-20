using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Solution.Presentation.Models
{
    public enum GenderVM {Female, Male }
    public class CandidateVM
    {
        public int CandidateId { get; set; }
        //   [Required(ErrorMessage = "this filed is required")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderVM Gender { get; set; }
        // [Required(ErrorMessage = "this filed is required")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirthday { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string ImageUrl { get; set; }



        //[Required(ErrorMessage = "this filed is required")]
        public string bio { get; set; }
    }
}