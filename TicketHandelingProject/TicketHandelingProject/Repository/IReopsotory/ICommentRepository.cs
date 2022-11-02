using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketHandelingProject.Models;
using TicketHandelingProject.Models.DTO;

namespace TicketHandelingProject.Repository.IReopsotory
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Boolean NewComment(CommentDto comment);
        IEnumerable<CommentDisplayDto> CommentByTicketId(int Id);
    }
}
