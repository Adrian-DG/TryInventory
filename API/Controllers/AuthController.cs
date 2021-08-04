using System.Threading.Tasks;
using API.DTO;
using API.Interfaces;
using API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController
    {
        private readonly IAuthRepository _authRepo;
        public AuthController(IAuthRepository authRepository)
        {
            _authRepo = authRepository;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDTO model)
        {
            return new JsonResult(await _authRepo.Register(model));                  
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDTO model)
        {
            return new JsonResult(await _authRepo.Login(model));                  
        }

        // TODO: remove this method
        [Authorize]
        [HttpGet("response")]
        public ActionResult GetResponse()
        {
            return new JsonResult(new { authorize = true });
        }

    }
}