using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string TypeNotification{ get; set; }
        public string Content { get; set; }
        public DateTime DateNotification { get; set; }




    }
}
