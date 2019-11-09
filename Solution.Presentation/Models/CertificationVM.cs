using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Solution.Presentation.Models
{
    public class CertificationVM
    {
        public string Designation { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateObtained { get; set; }
        [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }
        public string CredentialIdentification { get; set; }
    }
}