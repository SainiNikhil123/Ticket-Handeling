using System;
using System.Collections.Generic;

#nullable disable

namespace TicketHandelingProject.Models
{
    public partial class Priority
    {
        public Priority()
        {
            TicketPriorities = new HashSet<TicketPriority>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TicketPriority> TicketPriorities { get; set; }
    }
}
