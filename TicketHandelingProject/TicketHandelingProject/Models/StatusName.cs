using System;
using System.Collections.Generic;

#nullable disable

namespace TicketHandelingProject.Models
{
    public partial class StatusName
    {
        public StatusName()
        {
            TicketStatuses = new HashSet<TicketStatus>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TicketStatus> TicketStatuses { get; set; }
    }
}
