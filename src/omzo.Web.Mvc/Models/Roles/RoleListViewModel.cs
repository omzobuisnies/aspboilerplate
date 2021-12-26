using System.Collections.Generic;
using omzo.Roles.Dto;

namespace omzo.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
