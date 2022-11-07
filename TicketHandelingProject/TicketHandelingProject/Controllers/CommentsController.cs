using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketHandelingProject.Models.DTO;
using TicketHandelingProject.Repository.IReopsotory;

namespace TicketHandelingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CommentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        
        public IActionResult AddComment(CommentDto comment)
        {
            if(comment != null && ModelState.IsValid)
            {
                var newComment = _unitOfWork.Comment.NewComment(comment);
                if (newComment != true) return BadRequest();
                return Ok();
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult GetCommentsByTicketId(int ticketId)
        {
            if(ticketId != 0)
            {
                var comments = _unitOfWork.Comment.CommentByTicketId(ticketId);
                if (comments == null) return BadRequest();
                return Ok(comments);
            }
            return BadRequest();
        }
    }
}
