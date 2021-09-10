using System.Threading.Tasks;
using API.Data;
using API.DTO;
using API.Interfaces;
using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        private readonly IUnitOfWork<Employee> _uof;
        public AuthController(IAuthRepository authRepository, IUnitOfWork<Employee> uof)
        {
            _authRepo = authRepository;
            _uof = uof;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDTO model)
        {
            var result = await _authRepo.Register(model);

            if(result.Status) 
            {
                var newEmployee = new Employee 
                {
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    DoB = model.DoB,
                    Gender = model.Gender,
                    PhoneNumber = model.PhoneNumber,
                    EmailAddress = model.EmailAddress,
                    UserId = result.User.UserId
                };

                await _uof.Repository.Insert(newEmployee);
                await _uof.CommitChanges();
            }            
                              
            return new JsonResult(new ServerResponse { Message = result.Message, Status = result.Status });

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