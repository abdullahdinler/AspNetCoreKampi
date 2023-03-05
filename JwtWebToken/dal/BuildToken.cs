using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace JwtWebToken.dal
{
    public class BuildToken
    {
        public string CreateToken()
        {
            var bytes = Encoding.UTF8.GetBytes("aspnetcore");
            var key = new SymmetricSecurityKey(bytes);
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.Aes128CbcHmacSha256);
            JwtSecurityToken securityToken = new JwtSecurityToken(issuer: "http://localhost",
                audience: "http://localhost", notBefore: DateTime.Now, expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials);
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(securityToken);
        }
    }
}
