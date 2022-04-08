using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPIPractise.Model;

namespace WebAPI.Utility
{
    public class CustomJWTService : ICustomJWTService
    {
        //注入
        private readonly JWTTokenOptions _jWTTokenOptions;
        public CustomJWTService(IOptionsMonitor<JWTTokenOptions> jwtTokenOptions)
        {
            _jWTTokenOptions = jwtTokenOptions.CurrentValue;
        }
        /// <summary>
        /// 獲取token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string GetToken(Users user)
        {
            var claims = new[] { //可以包含很多東西
                new Claim("Id",user.Id.ToString()),
                new Claim("QQ",user.QQ),
                new Claim("nickName",user.NickName),
                new Claim("UserType",user.UserType.ToString()),
                new Claim("Mobile",user.Mobile.ToString()),
            };
            //需要加密,需要加密key
            //nuget引入
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jWTTokenOptions.SecurityKey));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _jWTTokenOptions.Issuer,
                audience: _jWTTokenOptions.Audience,
                claims:claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            string returnToken = new JwtSecurityTokenHandler().WriteToken(token);
            return returnToken;
        }
    }
}
