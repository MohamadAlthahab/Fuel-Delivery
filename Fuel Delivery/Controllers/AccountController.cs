using AutoMapper;
using Fuel_Delivery.Data;
using Fuel_Delivery.IRepository;
using Fuel_Delivery.Model;
using Fuel_Delivery.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Text;

namespace Fuel_Delivery.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IAuthManger _authManger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;
        public AccountController(UserManager<User> userManager, IMapper mapper, IAuthManger authManger, IUnitOfWork unitOfWork, IConfiguration config)
        {
            _userManager = userManager;
            _mapper = mapper;
            _authManger = authManger;
            _unitOfWork = unitOfWork;
            _config = config;
        }

        [HttpPost("Rigester")]
        public async Task<IActionResult> RegisterNewUser(NewUserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<User>(userDTO);
                var result = await _userManager.CreateAsync(user, userDTO.Password);
                await _userManager.AddToRolesAsync(user, userDTO.Role);
                if (result.Succeeded)
                {
                    return Ok("Success");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return BadRequest();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserDTO Login)
        {
            if (ModelState.IsValid)
            {
                var user = await _unitOfWork.User.Get(u => u.PhoneNumber == Login.PhoneNumber);
                if (user != null)
                {
                    if (await _userManager.CheckPasswordAsync(user , Login.Password))
                    {
                        var claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                        var roles = await _userManager.GetRolesAsync(user);
                        foreach (var role in roles)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
                        }
                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SecretKey"]));
                        var sc = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                            claims: claims,
                            issuer: _config["JWT:Issuer"],
                            audience: _config["JWT:Audience"],
                            expires: DateTime.Now.AddHours(1),
                            signingCredentials: sc
                            );
                        var _token = new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo,
                        };
                        return Ok(_token);
                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
                else
                {
                    ModelState.AddModelError("","User name is invalide");
                }
            }
            return Ok();
        }
    }
}
