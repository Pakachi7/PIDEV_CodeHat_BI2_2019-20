using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Message
    {
        public int MessageId { get; set; }
        public int UserId { get; set; }
        public int Destination { get; set; }
        public DateTime DateSend { get; set; }


    }
}
