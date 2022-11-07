using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketHandelingProject.Models;
using TicketHandelingProject.Models.DTO;

namespace TicketHandelingProject.Repository.IReopsotory
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        IEnumerable<TicketsDto> AllTickets();
        IEnumerable AllTicketsByUserId(string UserId);
        IEnumerable<CompletedTicketDto> AllCompletedTickets();
        Boolean NewTicket(TicketDto ticket);
        Boolean ApproveTicket(TicketUpdateDto ticketUpdate);
        IEnumerable<TicketsDto> ApprovedTickets();
        IEnumerable<DevTicketDto> TicketByDevId(string DevId);
        Boolean AddStatus(int ticketId, int statusId);
    }
}
