using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Availability
    {
        public int AvailabilityId { get; set; }
        public int Representator_Id { get; set; }
        public DateTime Availability_Date_Begin { get; set; }
        public DateTime Availability_Date_End { get; set; }

    }
}
