using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketHandelingProject.Repository.IReopsotory;

namespace TicketHandelingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public RolesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Authorize]
        [HttpGet]
        public IActionResult getRole()
        {
            var roles = _unitOfWork.Role.GetAll().ToList();
            var adminRole = roles.Where(x => x.Name == "Admin").FirstOrDefault();
            roles.Remove(adminRole);
            return Ok(roles);
        }
    }
}
