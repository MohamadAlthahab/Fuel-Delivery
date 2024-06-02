using AutoMapper;
using Fuel_Delivery.Data;
using Fuel_Delivery.IRepository;
using Fuel_Delivery.Model;
using Fuel_Delivery.Services;
using Microsoft.AspNetCore.Authorization;
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
        private readonly UserManager<Driver> _driverManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _config;
        public AccountController(UserManager<User> userManager, UserManager<Driver> driverManager,IMapper mapper, IUnitOfWork unitOfWork, IConfiguration config)
        {
            _userManager = userManager;
            _driverManager = driverManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _config = config;
        }

        [HttpPost]
        [Route("Rigester")]
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

        [HttpPost]
        [Route("LoginUser")]
        public async Task<IActionResult> LoginUser(LoginDTO Login)
        {
            if (ModelState.IsValid)
            {
                var user = await _unitOfWork.User.Get(u => u.PhoneNumber == Login.PhoneNumber);


                if (user != null)
                {

                    if (await _userManager.CheckPasswordAsync(user, Login.Password))
                    {
                        var claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                        claims.Add(new Claim(ClaimTypes.Role, "User"));
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
                    ModelState.AddModelError("", "User name is invalide");
                }
            }
            return Ok();
        }

        [HttpPost]
        [Route("LoginAdmin")]
        public async Task<IActionResult> LoginAdmin(LoginDTO Login)
        {
            if (ModelState.IsValid)
            {
                var admin = await _unitOfWork.Admin.Get(u => u.Phone == Login.PhoneNumber);
                if (admin != null)
                {
                    if(admin.Password == Login.Password)
                    {
                        var claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.NameIdentifier , admin.Id.ToString()));
                        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                        claims.Add(new Claim(ClaimTypes.Role, "Admin"));
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
                    ModelState.AddModelError("", "User name is invalide");
                }
            }
            return Ok();
        }

        [HttpPost]
        [Route("LoginDriver")]
        public async Task<IActionResult> LoginDriver(LoginDTO Login)
        {
            if (ModelState.IsValid)
            {
                var driver = await _unitOfWork.Driver.Get(u => u.Phone == Login.PhoneNumber);


                if (driver != null)
                {
                    if (await _driverManager.CheckPasswordAsync(driver, Login.Password))
                    {
                        var claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.Name, driver.FullName));
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, driver.Id.ToString()));
                        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                        claims.Add(new Claim(ClaimTypes.Role, "Driver"));
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
                    ModelState.AddModelError("", "User name is invalide");
                }
            }
            return Ok();
        }
    }
}
