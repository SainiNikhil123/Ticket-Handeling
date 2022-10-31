using System;
using System.Collections.Generic;

#nullable disable

namespace TicketHandelingProject.Models
{
    public partial class Ticket
    {
        public Ticket()
        {
            TicketComments = new HashSet<TicketComment>();
            TicketDevelopers = new HashSet<TicketDeveloper>();
            TicketPriorities = new HashSet<TicketPriority>();
            TicketStatuses = new HashSet<TicketStatus>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public string Ticket1 { get; set; }
        public string PicturePath { get; set; }
        public bool Approved { get; set; }

        public virtual AspNetUser User { get; set; }
        public virtual ICollection<TicketComment> TicketComments { get; set; }
        public virtual ICollection<TicketDeveloper> TicketDevelopers { get; set; }
        public virtual ICollection<TicketPriority> TicketPriorities { get; set; }
        public virtual ICollection<TicketStatus> TicketStatuses { get; set; }
    }
}
