using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
   public  class Comment
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
       

        public string Content { get; set; }
        public DateTime CommentDate { get; set; }


        public int NbrLikes { get; set; }
        //foreign key 
        public int? PostId { get; set; }
        public virtual Post Post{ get; set; }


    }
}
