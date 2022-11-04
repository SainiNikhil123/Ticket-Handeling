using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketHandelingProject.Repository.IReopsotory
{
    public interface IUnitOfWork
    {
        ITicketRepository Ticket { get; }
        IStatusRepository Status { get; }
        IPriorityRepository Priority { get; }
        ICommentRepository Comment { get; }
        IRoleRepository Role { get; }

    }
}
