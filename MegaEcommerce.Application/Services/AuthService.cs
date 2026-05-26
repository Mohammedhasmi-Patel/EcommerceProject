
using MegaEcommerce.Application.DTO.Auth;
using MegaEcommerce.Application.DTO.Common;
using MegaEcommerce.Application.RepositoryInterface;
using MegaEcommerce.Application.ServicesInterface;

namespace MegaEcommerce.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ApiResponse<string>> RegisterUserService(RegisterUserRequest registerUserRequest)
        {
            bool isUserExist = await _userRepository.IsUserExist(registerUserRequest.Email);
            if (isUserExist)
            {
                throw new BadRequestException("User already exist.");
            }
        }
    }
}
