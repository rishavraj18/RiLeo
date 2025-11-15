using RiLeo.Services.AuthAPI.Models;

namespace RiLeo.Services.AuthAPI.Services
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser);
    }
}
