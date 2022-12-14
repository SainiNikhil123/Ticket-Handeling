using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketHandelingProject.Models;
using TicketHandelingProject.Models.DTO;
using TicketHandelingProject.Repository.IReopsotory;

namespace TicketHandelingProject.Repository
{
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        private readonly Ticket_Handeling_ProjectContext _context;
        public TicketRepository(Ticket_Handeling_ProjectContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<TicketsDto> AllTickets()
        {
            // var Tickets = _context.Tickets.Where(x => x.Approved == false).ToList();
            var sss = _context.Tickets.Where(x => x.Approved == false).Select(x => x.UserId).ToList();
            var sssh = _context.Tickets.ToList().Count();
            var Tickets = (from t in _context.Tickets
                           join u in _context.AspNetUsers
                           on t.UserId equals u.Id
                           from ts in _context.TicketStatuses.Where(x => x.TicketId == t.Id).DefaultIfEmpty()
                           from tp in _context.TicketPriorities.Where(x => x.TicketId == t.Id).DefaultIfEmpty()
                           from td in _context.TicketDevelopers.Where(x => x.TicketId == t.Id).DefaultIfEmpty()
                           from s in _context.StatusNames.Where(x => x.Id == ts.StatusId).DefaultIfEmpty()
                           from p in _context.Priorities.Where(x => x.Id == tp.PriorityId).DefaultIfEmpty()
                           from d in _context.AspNetUsers.Where(x => x.Id == td.DeveloperId).DefaultIfEmpty()
                           select new TicketsDto()
                           {
                               Id = t.Id,
                               Ticket1 = t.Ticket1,
                               UserId = t.UserId,
                               User = u.UserName,
                               StatusId = ts.StatusId != 0 ? ts.StatusId : 0,
                               Status = ts.StatusId != 0 ? s.Name : null,
                               PriorityId = tp.PriorityId != 0 ? tp.PriorityId : 0,
                               Priority = tp.PriorityId != 0 ? p.Name : null,
                               Approved = t.Approved,
                               DeveloperId = td.DeveloperId != null ? td.DeveloperId : null,
                               Developer = td.DeveloperId != null ? d.UserName : null,
                               PicturePath = t.PicturePath
                           }).ToList();

            if (Tickets == null) return null;

            return Tickets;
        }

        public IEnumerable<DevTicketDto> TicketByDevId(string DevId)
        {
            var Tickets = (from t in _context.Tickets
                           join td in _context.TicketDevelopers
                           on t.Id equals td.TicketId
                           join ts in _context.TicketStatuses
                           on t.Id equals ts.TicketId
                           join tp in _context.TicketPriorities
                           on t.Id equals tp.TicketId
                           join s in _context.StatusNames
                           on ts.StatusId equals s.Id
                           join p in _context.Priorities
                           on tp.PriorityId equals p.Id
                           where td.DeveloperId == DevId
                           select new DevTicketDto()
                           {
                               Id = t.Id,
                               Ticket1 = t.Ticket1,
                               StatusId = ts.StatusId,
                               Status = s.Name,
                               PriorityId = tp.PriorityId,
                               Priority = p.Name,
                               PicturePath = t.PicturePath
                           }).ToList();

            if (Tickets == null) return null;

            return Tickets;
        }

        public IEnumerable AllTicketsByUserId(string UserId)
        {
            var Tickets = (from t in _context.Tickets
                           join u in _context.AspNetUsers
                           on t.UserId equals u.Id
                           from ts in _context.TicketStatuses.Where(x=>x.TicketId == t.Id).DefaultIfEmpty()                                                      
                           from s in _context.StatusNames.Where(x=>x.Id == ts.StatusId).DefaultIfEmpty()                         
                           where t.UserId == UserId
                           select new 
                           {
                               Id = t.Id,
                               Ticket1 = t.Ticket1,
                               StatusId = ts.StatusId,
                               Status = s.Name,
                               PicturePath = t.PicturePath
                           }).ToList();

            if (Tickets == null) return null;

            return Tickets;
        }

        public IEnumerable<CompletedTicketDto> AllCompletedTickets()
        {
            var Tickets = (from t in _context.Tickets
                           join td in _context.TicketDevelopers
                           on t.Id equals td.TicketId
                           join ts in _context.TicketStatuses
                           on t.Id equals ts.TicketId
                           join tp in _context.TicketPriorities
                           on t.Id equals tp.TicketId
                           join s in _context.StatusNames
                           on ts.StatusId equals s.Id
                           join d in _context.AspNetUsers
                           on td.DeveloperId equals d.Id
                           where s.Name == "Completed"
                           select new CompletedTicketDto()
                           {
                               Id = t.Id,
                               Ticket1 = t.Ticket1,
                               StatusId = ts.StatusId,
                               Status = s.Name,
                               DevId = td.DeveloperId,
                               Dev = d.UserName

                           }).ToList();

            if (Tickets == null) return null;

            return Tickets;
        }

        public IEnumerable<TicketsDto> ApprovedTickets()
        {
            var Tickets = (from t in _context.Tickets
                           join u in _context.AspNetUsers
                           on t.UserId equals u.Id
                           join ts in _context.TicketStatuses
                           on t.Id equals ts.TicketId
                           join tp in _context.TicketPriorities
                           on t.Id equals tp.TicketId
                           join td in _context.TicketDevelopers
                           on t.Id equals td.TicketId
                           join s in _context.StatusNames
                           on ts.StatusId equals s.Id
                           join p in _context.Priorities
                           on tp.PriorityId equals p.Id
                           join d in _context.AspNetUsers
                           on td.DeveloperId equals d.Id
                           where t.Approved == true
                           select new TicketsDto()
                           {
                               Id = t.Id,
                               Ticket1 = t.Ticket1,
                               UserId = t.UserId,
                               User = u.UserName,
                               StatusId = ts.StatusId,
                               Status = s.Name,
                               PriorityId = tp.PriorityId,
                               Priority = p.Name,
                               Approved = t.Approved,
                               DeveloperId = td.DeveloperId,
                               Developer = d.UserName,
                               PicturePath = t.PicturePath
                           });

            if (Tickets == null) return null;

            return Tickets;
        }

        public Boolean NewTicket(TicketDto ticket)
        {
            try
            {
                Ticket newTicket = new Ticket()
                {
                    Ticket1 = ticket.Ticket1,
                    UserId = ticket.UserId,
                    PicturePath = ticket.PicturePath,
                    Approved = false
                };
                _context.Tickets.Add(newTicket);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public Boolean AddStatus(int ticketId, int statusId)
        {
            try
            {
                var ticketStatus = _context.TicketStatuses.Where(x => x.TicketId == ticketId).ToList();

                _context.TicketStatuses.RemoveRange(ticketStatus);
                _context.SaveChanges();

                TicketStatus ticket = new TicketStatus()
                {
                    TicketId = ticketId,
                    StatusId = statusId
                };
                _context.TicketStatuses.Add(ticket);
                _context.SaveChanges();

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public Boolean ApproveTicket(TicketUpdateDto ticketUpdate)
        {
            try
            {
                var ticket = _context.Tickets.FirstOrDefault(x => x.Id == ticketUpdate.Id);
                if (ticket == null) return false;
                ticket.Approved = true;

                _context.Tickets.Update(ticket);
                _context.SaveChanges();

                TicketDeveloper ticketDeveloper = new TicketDeveloper()
                {
                    TicketId = ticketUpdate.Id,
                    DeveloperId = ticketUpdate.DeveloperId 
                };
                _context.TicketDevelopers.Add(ticketDeveloper);
                _context.SaveChanges();

                TicketStatus ticketStatus = new TicketStatus()
                {
                    TicketId = ticketUpdate.Id,
                    StatusId = ticketUpdate.StatusId
                };
                _context.TicketStatuses.Add(ticketStatus);
                _context.SaveChanges();

                TicketPriority ticketPriority = new TicketPriority()
                {
                    TicketId = ticketUpdate.Id,
                    PriorityId = ticketUpdate.PriorityId
                };
                _context.TicketPriorities.Add(ticketPriority);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
