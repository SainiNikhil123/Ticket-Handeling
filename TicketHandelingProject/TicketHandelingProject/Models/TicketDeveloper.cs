using System;
using System.Collections.Generic;

#nullable disable

namespace TicketHandelingProject.Models
{
    public partial class TicketDeveloper
    {
        public string DeveloperId { get; set; }
        public int TicketId { get; set; }

        public virtual AspNetUser Developer { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
