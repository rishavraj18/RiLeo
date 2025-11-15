using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RiLeo.Services.AuthAPI.Models.Dto;
using RiLeo.Services.AuthAPI.Services;

namespace RiLeo.Services.AuthAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthAPIController : ControllerBase
    {
        private readonly IAuthService _authService;
        protected ResponseDto _response;

        public AuthAPIController(IAuthService authService)
        {
            _authService = authService;
            _response = new();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto model)
        {
            var errorMessage = await _authService.Register(model);
            if (!string.IsNullOrEmpty(errorMessage)) 
            {
                _response.IsSucess = false;
                _response.Message = errorMessage;
                return BadRequest(_response);
            }
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var loginResponse = await _authService.Login(model);
            if(loginResponse.User == null)
            {
                _response.IsSucess = false;
                _response.Message = "Username or password is incorrect";
                return Unauthorized(_response);
            }

            _response.Result = loginResponse;
            return Ok(_response);
        }
    }
}
