using FortuneTellerApi.Models;
using System.Security.Claims;

namespace FortuneTellerApi.Repository.Interfaces
{
    public interface IJWTManagerRepository
    {
        Tokens GenerateToken(string userName);
        Tokens GenerateRefreshToken(string userName);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
