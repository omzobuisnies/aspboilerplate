using System.Collections.Generic;
using omzo.Roles.Dto;

namespace omzo.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}