using API.BusinessLayer;
using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace API.Controllers
{
    public class AccountController(DataContext context, ITokenService tokenService) : BaseApiController
    {
        [HttpPost("register")] // account/register
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Email))
                return BadRequest("This email is already registered");

           // using var hmac = new HMACSHA512();

            var user = new AppUser
            {
                Email = registerDto.Email.ToLower(),
                Name = registerDto.Name,
                //PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)).ToString(), // Csak hash
                PasswordHash = registerDto.Password,
                RoleId = 2
            };

            context.Felhasznalok.Add(user);
            await context.SaveChangesAsync();
            return new UserDto
            {
                Email = user.Email,
                Token = tokenService.CreateToken(user)
            };
        }

        private async Task<bool> UserExists(string email)
        {
            return await context.Felhasznalok.AnyAsync(x => x.Email == email.ToLower());
        }


        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await context.Felhasznalok.FirstOrDefaultAsync(x => x.Email == loginDto.Email.ToLower());

            if (user == null)
                return Unauthorized("Invalid email");

            //using var hmac = new HMACSHA512(); 
            //var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password)).ToString();

            if (!loginDto.Password.Equals(user.PasswordHash)) return Unauthorized("Invalid password");


            return new UserDto
            {
                Email=user.Email,
                Token = tokenService.CreateToken(user)
            };

        }
    }
}
