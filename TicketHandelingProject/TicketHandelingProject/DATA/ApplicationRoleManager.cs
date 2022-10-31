using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace TicketHandelingProject.DATA
{
    public class ApplicationRoleManager: RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(ApplicationRoleStore appRoleStore,
        IEnumerable<IRoleValidator<IdentityRole>> roleValidators,
        ILookupNormalizer lookupNormalizer, IdentityErrorDescriber identityErrorDescriber,
        ILogger<ApplicationRoleManager> logger) : base(appRoleStore, roleValidators, lookupNormalizer,
        identityErrorDescriber, logger)
        {

        }
    }
}
