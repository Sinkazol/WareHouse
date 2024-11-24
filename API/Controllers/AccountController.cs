using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace API.Controllers
{
    public class AccountController(DataContext context) : BaseApiController
    {
        [HttpPost("register")] //account/register
        //public async Task<ActionResult<AppUser>> Register(RegisterDto registerDto)
        //{
        //    if(await UserExists(registerDto.Username)) return BadRequest("Username is taken");
        //    using var hmac = new HMACSHA512();

        //    var user = new AppUser
        //    {
        //        Name = registerDto.Username.ToLower(),
        //        PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
        //        PasswordSalt = hmac.Key
        //    };
        //    context.Felhasznalok.Add(user);
        //    await context.SaveChangesAsync();
        //    return user;
        //}


        [HttpPost("login")]
        //public async Task<ActionResult<AppUser>> Login(LoginDto loginDto)
        //{
        //    var user= await context.Felhasznalok.FirstOrDefaultAsync(x=>
        //    x.Name == loginDto.Username.ToLower());

        //    if(user==null) return Unauthorized("Invalid username");
        //    //using var hmac = new HMACSHA512(user.PasswordSalt);
        //   // var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

        //    for(int i = 0; i < computedHash.Length; i++)
        //    {
        //        if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
        //    }
        //    return user;
        //}
        private async Task<bool> UserExists(string username)
        {
            return await context.Felhasznalok.AnyAsync(x=>x.Name.ToLower() == username);
        }
    }
}
