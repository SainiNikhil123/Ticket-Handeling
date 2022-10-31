using System;
using System.Collections.Generic;

#nullable disable

namespace TicketHandelingProject.Models
{
    public partial class TicketPriority
    {
        public int TicketId { get; set; }
        public int PriorityId { get; set; }

        public virtual Priority Priority { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
