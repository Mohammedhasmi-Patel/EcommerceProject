using MegaEcommerce.Application.DTO.Auth;
using MegaEcommerce.Application.DTO.Common;
using MegaEcommerce.Application.ServicesInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MegaEcommerce.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("/register")]
        public ApiResponse<string> RegisterUser([FromForm] RegisterUserRequest registerUserRequest)
        {
            return _authService.RegisterUserService(registerUserRequest);
        }
    }
}
