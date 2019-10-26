using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Reaction
    {
        public int ReactionId { get; set; }
        public string TypeReaction { get; set; }
        public int PublicationId { get; set; }//fk

    }
}
