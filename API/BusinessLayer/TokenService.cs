﻿using API.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.BusinessLayer
{
    public class TokenService(IConfiguration config) : ITokenService
    {
        public string CreateToken(AppUser user)
        {
            var tokenKey = config["TokenKey"] ?? throw new Exception("Cannot access tokenKey from a appsettings");
            if (tokenKey.Length < 64) throw new Exception("Your tokenKy needs to be longer");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
        
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Name),
                new("RoleId", user.RoleId.ToString())
            };

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = creds

            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
