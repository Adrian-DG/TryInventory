using API.DTO;
using System;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IAuthRepository
    {
        Task<object> Register(RegisterDTO model);
        Task<object> Login(LoginDTO model);
        Task<bool> UserExist(string username);
    }
}