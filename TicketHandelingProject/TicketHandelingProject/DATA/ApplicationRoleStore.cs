using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketHandelingProject.DATA
{
    public class ApplicationRoleStore : RoleStore<IdentityRole, ApplicationDbContext>
    {
        public ApplicationRoleStore(ApplicationDbContext context, IdentityErrorDescriber errorDescriber) : base(context, errorDescriber)
        {

        }
    }
}
