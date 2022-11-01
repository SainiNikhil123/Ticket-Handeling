using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketHandelingProject.Models;
using TicketHandelingProject.Models.DTO;

namespace TicketHandelingProject.Repository.IReopsotory
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        IEnumerable<Ticket> AllTickets();
        Boolean NewTicket(TicketDto ticket);
        Boolean ApproveTicket(TicketUpdateDto ticketUpdate);
        IEnumerable<TicketsDto> ApprovedTickets();
    }
}
