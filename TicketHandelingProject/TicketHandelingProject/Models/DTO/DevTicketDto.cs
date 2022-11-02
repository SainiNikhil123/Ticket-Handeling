using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketHandelingProject.Models.DTO
{
    public class DevTicketDto
    {
        public int Id { get; set; }
        public int PriorityId { get; set; }
        public string Priority { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
        public string Ticket1 { get; set; }
    }
}
