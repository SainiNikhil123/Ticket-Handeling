using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketHandelingProject.Models;
using TicketHandelingProject.Repository.IReopsotory;

namespace TicketHandelingProject.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Ticket_Handeling_ProjectContext _Context;
        public UnitOfWork(Ticket_Handeling_ProjectContext Context)
        {
            _Context = Context;
            Ticket = new TicketRepository(_Context);
            Status = new StatusRepository(_Context);
            Priority = new PriorityRepository(_Context);
        }

        public ITicketRepository Ticket { get; private set; }

        public IStatusRepository Status { get; private set; }

        public IPriorityRepository Priority { get; private set; }
    }
}
