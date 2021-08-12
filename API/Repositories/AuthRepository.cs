using System;
using System.Threading.Tasks;
using API.DTO;
using API.Data;
using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace API.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApiContext _context;

        private readonly IConfiguration _configuration;

        public AuthRepository(ApiContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<object> Login(LoginDTO model)
        {
            if(! (await UserExist(model.Username))) return new ServerResponse { Message="Username is not valid", Status= false };

            var user = await _context.AppUsers.SingleOrDefaultAsync(x => x.Username == model.Username);            

            return  VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt)
                    ? new ServerResponse { Message = CreateToken(user), Status = true }
                    : new ServerResponse { Message = "User signin failed", Status = false };
        }

        public async Task<object> Register(RegisterDTO model)
        {
            if(await UserExist(model.Username)) return new ServerResponse { Message = "That username already exist", Status = false };

            CreatePasswordHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new AppUser 
            {
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                DoB = model.DoB,
                Username = model.Username,
                PhoneNumber = model.PhoneNumber,
                EmailAddress = model.EmailAddress,
                Gender = model.Gender,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = Roles.User
            };

            await _context.AppUsers.AddAsync(user);
            return  await _context.SaveChangesAsync() > 0 
                    ? new ServerResponse { Message = "User registered successfully", Status = true }   
                    : new ServerResponse { Message = "Something went wrong during registration", Status = false };                    
        }

        public async Task<bool> UserExist(string username)
        {
            return await _context.AppUsers.AnyAsync(user => user.Username.ToLower() == username.ToLower());
        }

        private string CreateToken(AppUser model)
        {
            List<Claim> claims = new List<Claim>
            {
              new Claim(ClaimTypes.NameIdentifier, model.UserId.ToString()),
              new Claim(ClaimTypes.Name, model.Username),
              new Claim(ClaimTypes.Role, model.Role)
            };
        
            var SecretKey = _configuration.GetSection("SecretKey").Value;
            var SimmetricKey = new SymmetricSecurityKey(ASCIIEncoding.UTF8.GetBytes(SecretKey));
        
            SigningCredentials credentials  = new SigningCredentials(SimmetricKey, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDecriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDecriptor);

            return tokenHandler.WriteToken(token);
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(ASCIIEncoding.UTF8.GetBytes(password));
                for (int i=0; i < computedHash.Length; i++)
                {
                    if(computedHash[i] != passwordHash[i]) return false;    
                }
            }

            return true;
        }        

        // OUT keyword enables the passwordSalt and passwordHash on Register() without the need of using return 
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.ASCIIEncoding.UTF8.GetBytes(password));
            }
        }
    }
}