using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        protected readonly ILogger<TicketController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public TicketController(IUnitOfWork unitOfWork, ILogger<TicketController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        [HttpGet]
        [Authorize(Roles =SD.Role_Admin+","+SD.Role_Admin_User)]
        public IActionResult GetTickets() // In This Method All Tickts Will Display For Admin Role
        {
            _logger.LogInformation("Run endpoint {endpoint} {verb}", "/api/Ticket", "GET");
            var tickets = _unitOfWork.Ticket.AllTickets();
            if (tickets == null) return BadRequest();
            return Ok(tickets);
        }
        [Authorize(Roles =SD.Role_Admin)]
        [HttpGet("Completed")]
        public IActionResult GetCompletedTickets() // In This Method Completed Tickts Will Display For Admin Role
        {
            _logger.LogInformation("Run endpoint {endpoint} {verb}", "/api/Ticket/Completed", "GET");
            var tickets = _unitOfWork.Ticket.AllCompletedTickets();
            if (tickets == null) return BadRequest();
            return Ok(tickets);
        }
        [HttpGet("Approved")]
        [Authorize(Roles =SD.Role_Support)]
        public IActionResult GetApprovedTickets() // In This Method Approved Tickts Will Display For Admin And Dev Support Role
        {
            _logger.LogInformation("Run endpoint {endpoint} {verb}", "/api/Ticket/Approved", "GET");
            var tickets = _unitOfWork.Ticket.ApprovedTickets();
            if (tickets == null) return BadRequest();
            return Ok(tickets);
        }
        [Authorize(Roles =SD.Role_Dev)]
        [HttpGet("DevTickets")]
        public IActionResult GetTicketsByDevId(string DevId) // In This Method Approved Tickts Will Display For Dev Role
        {
            _logger.LogInformation("Run endpoint {endpoint} {verb}", "/api/Ticket/DevTickets", "GET");
            var tickets = _unitOfWork.Ticket.TicketByDevId(DevId);
            if (tickets == null) return BadRequest();
            return Ok(tickets);
        }
        [Authorize(Roles =SD.Role_User)]
        [HttpGet("UserTickets")]
        public IActionResult GetTicketsByUserId(string UserId) // In This Method Approved Tickts Will Display For User Role
        {
            _logger.LogInformation("Run endpoint {endpoint} {verb}", "/api/Ticket/UserTickets", "GET");
            var tickets = _unitOfWork.Ticket.AllTicketsByUserId(UserId);
            if (tickets == null) return BadRequest();
            return Ok(tickets);
        }
        [Authorize]
        [HttpPost("Upload"), DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            _logger.LogInformation("Run endpoint {endpoint} {verb}", "/api/Ticket/Upload", "POST");

            try
            {
                var file = Request.Form.Files[0];
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
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddTicket([FromBody]TicketDto ticket)  //New Ticket Is Generating
        {
            _logger.LogInformation("Run endpoint {endpoint} {verb}", "/api/Ticket", "POST");
            try
            {
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
        [Authorize(Roles =SD.Role_Admin)]
        public IActionResult ApproveTicket([FromBody]TicketUpdateDto ticketUpdate)
        {
            _logger.LogInformation("Run endpoint {endpoint} {verb}", "/api/Ticket/Approve", "POST");
            var ticketupdated = _unitOfWork.Ticket.ApproveTicket(ticketUpdate);
            if (ticketupdated == false) return BadRequest();
            return Ok();
        }
        [HttpPost("UpdateStatus")]
        public IActionResult UpdateTicketStatus(StatusUpdDto status)
        {
            _logger.LogInformation("Run endpoint {endpoint} {verb}", "/api/Ticket/UpdateStatus", "POST");

            if (status != null && ModelState.IsValid)
            {
                var statusUpdated = _unitOfWork.Ticket.AddStatus(status.TicketId, status.StatusId);
                if (statusUpdated == false) return BadRequest();
                return Ok();
            }
            return BadRequest();
             
        }
    }
}
