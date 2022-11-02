using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketHandelingProject.Models.DTO
{
    public class CommentDisplayDto
    {
        public int Id { get; set; }
        public string Comment1 { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserRole { get; set; }
    }
}
