using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TicketHandelingProject.Models;

namespace TicketHandelingProject.DATA
{
    public class ApplicationUser: IdentityUser
    {
        [NotMapped]
        public string Role { get; set; }
    }
}
