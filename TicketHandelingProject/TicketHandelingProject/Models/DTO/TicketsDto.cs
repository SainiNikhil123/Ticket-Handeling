using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketHandelingProject.Models.DTO
{
    public class TicketsDto
    {
        public int Id { get; set; }
        public bool Approved { get; set; }
        public int? PriorityId { get; set; }
        public string Priority { get; set; }
        public int? StatusId { get; set; }
        public string Status { get; set; }
        public string DeveloperId { get; set; }
        public string Developer { get; set; }
        public string UserId { get; set; }
        public string User { get; set; }
        public string Ticket1 { get; set; }
        public string PicturePath { get; set; }

    }
}
