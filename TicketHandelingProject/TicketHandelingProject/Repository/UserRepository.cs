using Doc_Patient_Project.Models.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TicketHandelingProject.DATA;
using TicketHandelingProject.Models.DTO;
using TicketHandelingProject.Repository.IReopsotory;

namespace TicketHandelingProject.Repository
{
    public class UserRepository : IUserRepository
    {
        
        private readonly ApplicationUserManager _applicationUserManager;
        private readonly ApplicationSignInManager _applicationSignInManager;
        private readonly IConfiguration _iconfiguration;
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context, ApplicationUserManager applicationUserManager, ApplicationSignInManager applicationSignInManager, IConfiguration iconfiguration)
        {
            _applicationUserManager = applicationUserManager;
            _applicationSignInManager = applicationSignInManager;
            _iconfiguration = iconfiguration;
            _context = context;
        }

        public async Task<Token> Authenticate(Login login)
        {
            var result = await _applicationSignInManager.PasswordSignInAsync(login.UserName, login.Password, false, false);
            if (result.Succeeded)
            {
                var UserInDb = await _applicationUserManager.FindByNameAsync(login.UserName);
                UserInDb.PasswordHash = "";
                //JWT
                if (await _applicationUserManager.IsInRoleAsync(UserInDb, SD.Role_Admin))
                    UserInDb.Role = SD.Role_Admin;
                if (await _applicationUserManager.IsInRoleAsync(UserInDb, SD.Role_Admin_User))
                    UserInDb.Role = SD.Role_Admin_User;
                if (await _applicationUserManager.IsInRoleAsync(UserInDb, SD.Role_Support))
                    UserInDb.Role = SD.Role_Support;
                if (await _applicationUserManager.IsInRoleAsync(UserInDb, SD.Role_Dev))
                    UserInDb.Role = SD.Role_Dev;
                if (await _applicationUserManager.IsInRoleAsync(UserInDb, SD.Role_User))
                    UserInDb.Role = SD.Role_User;

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_iconfiguration["JWT:Key"]);
                var tokenDescritor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, UserInDb.UserName),
                    new Claim("Id",UserInDb.Id),
                    new Claim(ClaimTypes.Role, UserInDb.Role),
                    }),/*.Union(userClaims)),*/

                    Issuer = _iconfiguration["jwt:Issuer"],
                    Audience = _iconfiguration["jwt:Audience"],
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescritor);
                Token ValidToken = new Token()
                {
                    token = tokenHandler.WriteToken(token),
                };

                return ValidToken;
            }
            else
                return null;
        }

        public async Task<bool> Register(UserDto user)
        {
            if(user != null)
            {
                var users = new ApplicationUser();
                users.UserName = user.UserName;
                users.Email = user.Email;
                users.PhoneNumber = user.PhoneNumber;
                var userpassword = user.Password;
                var chkuser = await _applicationUserManager.CreateAsync(users, userpassword);

                if (chkuser.Succeeded)
                {
                    await _applicationUserManager.AddToRoleAsync(users, user.Role);
                }
                return true;
            }
            return false;
        }
        public async Task<bool> IsUniqueUser(string UserName)
        {
            var User = await _applicationUserManager.FindByNameAsync(UserName);
            if (User == null) return true; else return false;
        }
    }
}

