using MegaEcommerce.Application.DTO.Auth;
using MegaEcommerce.Application.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaEcommerce.Application.ServicesInterface
{
    public interface IAuthService
    {
        public Task<ApiResponse<string>> RegisterUserService(RegisterUserRequest registerUserRequest);
    }
}
