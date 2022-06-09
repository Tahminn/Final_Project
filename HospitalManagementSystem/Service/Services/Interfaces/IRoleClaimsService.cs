using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IRoleClaimsService
    {
        Task<PermissionDTO> GetRoleClaims(string roleId);
    }
}
