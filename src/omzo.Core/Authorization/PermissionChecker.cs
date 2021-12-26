using Abp.Authorization;
using omzo.Authorization.Roles;
using omzo.Authorization.Users;

namespace omzo.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
