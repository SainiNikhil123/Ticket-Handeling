using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace TicketHandelingProject.DATA
{
    public class ApplicationRoleManager: RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(ApplicationRoleStore appRoleStore,
        IEnumerable<IRoleValidator<ApplicationRole>> roleValidators,
        ILookupNormalizer lookupNormalizer, IdentityErrorDescriber identityErrorDescriber,
        ILogger<ApplicationRoleManager> logger) : base(appRoleStore, roleValidators, lookupNormalizer,
        identityErrorDescriber, logger)
        {

        }
    }
}
