using RiLeo.Services.AuthAPI.Models;
using System.Collections;

namespace RiLeo.Services.AuthAPI.Services
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
    }
}
