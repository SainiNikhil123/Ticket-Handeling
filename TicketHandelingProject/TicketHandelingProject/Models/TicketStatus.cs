using System;
using System.Collections.Generic;

#nullable disable

namespace TicketHandelingProject.Models
{
    public partial class TicketStatus
    {
        public int Id { get; set; }
        public int TicketId { get; set; }
        public int StatusId { get; set; }

        public virtual StatusName Status { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
