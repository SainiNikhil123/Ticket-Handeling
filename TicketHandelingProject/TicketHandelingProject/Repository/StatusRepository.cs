using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketHandelingProject.Models;
using TicketHandelingProject.Repository.IReopsotory;

namespace TicketHandelingProject.Repository
{
    public class StatusRepository:Repository<StatusName>, IStatusRepository
    {
        private readonly Ticket_Handeling_ProjectContext _context;
        public StatusRepository(Ticket_Handeling_ProjectContext context) : base(context)
        {
            _context = context;
        }
    }
}
