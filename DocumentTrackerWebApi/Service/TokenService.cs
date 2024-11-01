//using System;
//using System.Collections.Generic;
//using System.IdentityModel.Tokens.Jwt;
//using System.Linq;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;
//using DocumentTracker.Models;
//using DocumentTrackerWebApi.Interfaces;
//using Microsoft.AspNetCore.Authorization.Infrastructure;
//using Microsoft.IdentityModel.Tokens;

//namespace DocumentTrackerWebApi.Service
//{
//    public class TokenService : ITokenService
//    {
//        public readonly IConfiguration _config;
//        public readonly SymmetricSecurityKey _key;
//        public TokenService(IConfiguration config)
//        {

//            _config = config;
//            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]));


//        }



//        public string CreateToken(User user)
//        {
//            var claims = new List<Claim>{
//                new Claim(JwtRegisteredClaimNames.Email, user.Email),
//                new Claim(JwtRegisteredClaimNames.GivenName, user.UserName),

//            };
//            var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);

//            var tokenDescriptor = new SecurityTokenDescriptor
//            {
//                Subject = new ClaimsIdentity(claims),
//                Expires = DateTime.Now.AddDays(7),
//                SigningCredentials = cred,
//                Issuer = _config["JWT:Issuer"],
//                Audience = _config["JWT:Audience"]
//            };

//            var tokenHandler = new JwtSecurityTokenHandler();

//            var token = tokenHandler.CreateToken(tokenDescriptor);

//            return tokenHandler.WriteToken(token);



//        }


//    }
//}