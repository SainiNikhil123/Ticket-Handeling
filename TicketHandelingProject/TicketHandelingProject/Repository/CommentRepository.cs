using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketHandelingProject.Models;
using TicketHandelingProject.Models.DTO;
using TicketHandelingProject.Repository.IReopsotory;

namespace TicketHandelingProject.Repository
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private readonly Ticket_Handeling_ProjectContext _context;
        public CommentRepository(Ticket_Handeling_ProjectContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<CommentDisplayDto> CommentByTicketId(int ticketId)
        {
            var ticket = _context.Tickets.Find(ticketId);
            if (ticket == null) return null;
            var comments = (from c in _context.Comments
                            join u in _context.AspNetUsers
                            on c.UserId equals u.Id
                            join ur in _context.AspNetUserRoles
                            on u.Id equals ur.UserId
                            join r in _context.AspNetRoles
                            on ur.RoleId equals r.Id
                            join tc in _context.TicketComments
                            on c.Id equals tc.CommentId
                            where tc.TicketId == ticketId
                            select new CommentDisplayDto()
                            {
                                Id = c.Id,
                                Comment1 = c.Comment1,
                                UserId = c.UserId,
                                UserName = u.UserName,
                                UserRole = r.Name
                            }).ToList();

            if (comments == null) return null;

            return comments;
        }

        public Boolean NewComment(CommentDto comment)
        {
            try
            {
                Comment newComment = new Comment()
                {
                    UserId = comment.UserId,
                    Comment1 = comment.Comment1
                };
                _context.Comments.Add(newComment);
                _context.SaveChanges();

                TicketComment ticketComment = new TicketComment()
                {
                    TicketId = comment.TicketId,
                    CommentId = newComment.Id
                };
                _context.TicketComments.Add(ticketComment);
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
