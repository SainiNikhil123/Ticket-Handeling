using Doc_Patient_Project.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketHandelingProject.Models.DTO;

namespace TicketHandelingProject.Repository.IReopsotory
{
    public interface IUserRepository
    {
        Task<bool> IsUniqueUser(string UserName);
        Task<Token> Authenticate(Login login);
        Task<Boolean> Register(UserDto user);
    }
}
