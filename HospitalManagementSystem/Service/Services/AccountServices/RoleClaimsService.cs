using Microsoft.AspNetCore.Identity;
using Service.Constants;
using Service.DTOs.ControllerPropDTOs.AccountDTOs;
using Service.Helpers;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.AccountServices
{
    public class RoleClaimsService : IRoleClaimsService
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleClaimsService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<PermissionDTO> GetRoleClaims(string roleId)
        {
            var model = new PermissionDTO();
            var allPermissions = new List<RoleClaimsDTO>();
            allPermissions.GetPermissions(typeof(PolicyTypes.Patients), roleId);
            var role = await _roleManager.FindByIdAsync(roleId);
            model.RoleId = roleId;
            var claims = await _roleManager.GetClaimsAsync(role);
            var allClaimValues = allPermissions.Select(a => a.Value).ToList();
            var roleClaimValues = claims.Select(a => a.Value).ToList();
            var authorizedClaims = allClaimValues.Intersect(roleClaimValues).ToList();
            foreach (var permission in allPermissions)
            {
                if (authorizedClaims.Any(a => a == permission.Value))
                {
                    permission.Selected = true;
                }
            }
            model.RoleClaims = allPermissions;
            return model;
        }
    }
}
