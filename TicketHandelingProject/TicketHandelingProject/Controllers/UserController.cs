using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketHandelingProject.DATA;
using TicketHandelingProject.Models.DTO;
using TicketHandelingProject.Repository.IReopsotory;

namespace TicketHandelingProject.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserController(IUserRepository userRepository, RoleManager<IdentityRole> roleManager)
        { 
            _userRepository = userRepository;
            _roleManager = roleManager;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserDto user)
        {
            if (!await _roleManager.RoleExistsAsync(SD.Role_Admin))
            {
                var role = new ApplicationRole();
                role.Name = SD.Role_Admin;
                await _roleManager.CreateAsync(role);
            }
            if (!await _roleManager.RoleExistsAsync(SD.Role_Admin_User))
            {
                var role = new ApplicationRole();
                role.Name = SD.Role_Admin_User;
                await _roleManager.CreateAsync(role);
            }
            if (!await _roleManager.RoleExistsAsync(SD.Role_Support))
            {
                var role = new ApplicationRole();
                role.Name = SD.Role_Support;
                await _roleManager.CreateAsync(role);
            }
            if (!await _roleManager.RoleExistsAsync(SD.Role_Dev))
            {
                var role = new ApplicationRole();
                role.Name = SD.Role_Dev;
                await _roleManager.CreateAsync(role);
            }
            if (!await _roleManager.RoleExistsAsync(SD.Role_User))
            {
                var role = new ApplicationRole();
                role.Name = SD.Role_User;
                await _roleManager.CreateAsync(role);
            }

            if (user != null && ModelState.IsValid)
            {
                var uniqueUser = await _userRepository.IsUniqueUser(user.UserName);
                if (uniqueUser == false) return BadRequest();
                var reguser = await _userRepository.Register(user);
                if (reguser == false) return BadRequest();
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate(Login login)
        {
            if(login != null && ModelState.IsValid)
            {
                var user = await _userRepository.Authenticate(login);
                if (user == null) return BadRequest();
                return Ok(user);
            }
            return BadRequest();

        }
    }
}
