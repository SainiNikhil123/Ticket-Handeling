using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketHandelingProject.Models.DTO
{
    public class TicketUpdateDto
    {
        public int Id { get; set; }
        public bool Approved { get; set; }
        public int Priority { get; set; }
        public int StatusId { get; set; }
        public string DeveloperId { get; set; }
    }
}
