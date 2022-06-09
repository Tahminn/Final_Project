using Microsoft.AspNetCore.Identity;
using Service.Models;
using System.Security.Claims;

namespace Service.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateJwtToken(string username, string name, string surname, int expireDuration, List<string> roles, List<IList<Claim>> roleClaims);
    }
}
