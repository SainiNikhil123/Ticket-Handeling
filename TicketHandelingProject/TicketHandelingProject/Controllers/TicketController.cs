using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TicketHandelingProject.Models.DTO;
using TicketHandelingProject.Repository.IReopsotory;

namespace TicketHandelingProject.Controllers
{
    [Route("api/Ticket")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TicketController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetTickets() // In This Method All Tickts Will Display For Admin Role
        {
            var tickets = _unitOfWork.Ticket.AllTickets();
            if (tickets == null) return BadRequest();
            return Ok(tickets);
        }
        [HttpGet("Approved")]
        public IActionResult GetApprovedTickets() // In This Method Approved Tickts Will Display For Admin And Dev Support Role
        {
            var tickets = _unitOfWork.Ticket.ApprovedTickets();
            if (tickets == null) return BadRequest();
            return Ok(tickets);
        }
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult AddTicket([FromBody]TicketDto ticket)  //New Ticket Is Generating
        {
            try
            {
                if (ticket.Picture != null)
                {
                    var file = ticket.Picture;
                    var folderName = Path.Combine("Resource", "Images");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                    if (file.Length > 0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                        var fullPath = Path.Combine(pathToSave, fileName);
                        var dbPath = Path.Combine(folderName, fileName);

                        using (var stream = new FileStream(fullPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }

                        ticket.PicturePath = dbPath;
                    }
                }
                else
                {
                    ticket.PicturePath = "";
                }

                var newTicket = _unitOfWork.Ticket.NewTicket(ticket);
                if (newTicket == false) return BadRequest();
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }
        [HttpPost("Approve")]
        public IActionResult ApproveTicket([FromBody]TicketUpdateDto ticketUpdate)
        {
            var ticketupdated = _unitOfWork.Ticket.ApproveTicket(ticketUpdate);
            if (ticketupdated == false) return BadRequest();
            return Ok();
        }
    }
}
