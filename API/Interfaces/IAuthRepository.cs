using API.DTO;
using System;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IAuthRepository
    {
        Task<RegisterResponse> Register(RegisterDTO model);
        Task<LoginResponse> Login(LoginDTO model);
        Task<bool> UserExist(string username);
    }
}