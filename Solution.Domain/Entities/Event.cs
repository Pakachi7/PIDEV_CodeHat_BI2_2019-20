using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Event
    {
        public int EventId { get; set; }
        public string Event_Title { get; set; }
        public string Event_Description { get; set; }
        public string Event_Organizer { get; set; }

        public DateTime Event_Date { get; set; }

        //   private Address Event_Address { get; set; }
        public int NumberOfParticipent { get; set; }
        //prop nav
        public int? CompanyId { get; set; }

        [ForeignKey("CompanyId")]

        public virtual Company Company { get; set; }


    }
}
