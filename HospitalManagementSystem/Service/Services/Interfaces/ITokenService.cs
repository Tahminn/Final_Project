using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Service.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateJwtToken(User user, List<Claim> roleClaims);
    }
}
