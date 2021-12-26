using System.Collections.Generic;
using omzo.Roles.Dto;

namespace omzo.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
