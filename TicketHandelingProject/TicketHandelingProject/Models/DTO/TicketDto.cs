using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketHandelingProject.Models.DTO
{
    public class TicketDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string User { get; set; }
        public string Ticket1 { get; set; }
        public string PicturePath { get; set; } 
        public bool Approved { get; set; }
    }
}
