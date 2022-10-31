using System;
using System.Collections.Generic;

#nullable disable

namespace TicketHandelingProject.Models
{
    public partial class Comment
    {
        public Comment()
        {
            TicketComments = new HashSet<TicketComment>();
        }

        public int Id { get; set; }
        public string Comment1 { get; set; }
        public string UserId { get; set; }

        public virtual AspNetUser User { get; set; }
        public virtual ICollection<TicketComment> TicketComments { get; set; }
    }
}
