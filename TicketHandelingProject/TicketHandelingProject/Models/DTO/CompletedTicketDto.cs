using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketHandelingProject.Models.DTO
{
    public class CompletedTicketDto
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
        public string DevId { get; set; }
        public string Dev { get; set; }
        public string Ticket1 { get; set; }
    }
}
