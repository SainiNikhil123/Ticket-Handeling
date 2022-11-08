using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketHandelingProject.Models.DTO;
using TicketHandelingProject.Repository.IReopsotory;

namespace TicketHandelingProject.Controllers
{
    [Route("api/Comments")]
    [ApiController]
    [Authorize]
    public class CommentsController : ControllerBase
    {
        protected readonly ILogger<CommentsController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public CommentsController(IUnitOfWork unitOfWork, ILogger<CommentsController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        [HttpPost]
        
        public IActionResult AddComment(CommentDto comment)
        {
            if(comment != null && ModelState.IsValid)
            {
                _logger.LogInformation("Run endpoint {endpoint} {verb}", "/api/Comments", "POST");
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
                _logger.LogInformation("Run endpoint {endpoint} {verb}", "/api/Comments", "GET");
                var comments = _unitOfWork.Comment.CommentByTicketId(ticketId);
                if (comments == null) return BadRequest();
                return Ok(comments);
            }
            return BadRequest();
        }
    }
}
