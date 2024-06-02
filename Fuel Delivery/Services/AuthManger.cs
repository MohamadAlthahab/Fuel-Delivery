using Fuel_Delivery.Data;
using Fuel_Delivery.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Fuel_Delivery.Services
{
    public class AuthManger : IAuthManger
    {
        private readonly UserManager<User> _userManger;
        private readonly IConfiguration _configuration;
        private User _user;

        public AuthManger(UserManager<User> userManger, IConfiguration configuration)
        {
            _userManger = userManger;
            _configuration = configuration;
        }
        public async Task<string> CreateToken()
        {
            var signingCredentials = GetsigningCredentials();
            var claims = await GetClaims();
            var token = GeneratTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private JwtSecurityToken GeneratTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var JwtSettings = _configuration.GetSection("JWT");
            var expiration = DateTime.Now.AddMinutes(Convert.ToDouble
                (JwtSettings.GetSection("lifetime").Value));
            var token = new JwtSecurityToken(
                issuer: JwtSettings.GetSection("Issuer").Value,
                claims: claims,
                expires: expiration,
                signingCredentials: signingCredentials
                );
            return token;
        }

        private async Task<List<Claim>> GetClaims()
        {
            /*  var claims = new List<Claim>
              {
                  new Claim(ClaimTypes.NameIdentifier, _user.Id)

              };
              var roles = await _userManger.GetRolesAsync(_user);

              foreach (var role in roles)
              {
                  claims.Add(new Claim(ClaimTypes.Role, role));
              }*/
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, _user.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, _user.Id));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            var roles = await _userManger.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }
            return claims;
        }

        private SigningCredentials GetsigningCredentials()
        {
            var JwtSettings = _configuration.GetSection("JWT");
            var key = _configuration.GetSection("JWT:KEY").Value;
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public async Task<bool> ValidateUser(LoginDTO userDTO)
        {
            _user = await _userManger.FindByNameAsync(userDTO.PhoneNumber);
            return (_user != null && await _userManger.CheckPasswordAsync(_user, userDTO.Password));
        }
    }
}
