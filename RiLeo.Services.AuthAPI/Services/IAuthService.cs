using RiLeo.Services.AuthAPI.Models.Dto;

namespace RiLeo.Services.AuthAPI.Services
{
    public interface IAuthService
    {
        Task<string> Register(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
    }
}
