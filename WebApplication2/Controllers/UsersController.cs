using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pos.BLL.Interface;
using pos.BLL.DTO;
using pos.BLL;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using WebApplication2.Helpers;
using Microsoft.Extensions.Options;

namespace WebApplication2.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserBLL _userBLL;
        private readonly IRoleBLL _roleBLL;

        private readonly AppSettings _appSettings;
        public UsersController(IUserBLL userBLL, IRoleBLL roleBLL, IOptions<AppSettings> appSettings)
        {
            _userBLL = userBLL;
            _roleBLL = roleBLL;
            _appSettings = appSettings.Value;
          
        }
        [HttpPost("register")]
        public IActionResult Insert(UserCreateDTO userCreateDTO)
        {
            try
            {
                _userBLL.Insert(userCreateDTO);
                return Ok("User added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("login")]
        public IActionResult Login(LoginDTO loginDTO)
        {
            var user = _userBLL.LoginWithToken(loginDTO);
            if(user == null)
            {
                return BadRequest(new { message = "Username or Pass incorect" });
            }
            var userWithRoles = _userBLL.GetUserWithRoles(user.Username);
            List<Claim>claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.Username));
            foreach(var role in userWithRoles.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.RoleName));
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var userWithToken = new
            {
                user = userWithRoles,
                token = tokenHandler.WriteToken(token)

            };
            return Ok(userWithToken);
           

        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var users = _userBLL.GetAllWithRoles();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("{username}")]
        
        public IActionResult AddUserToRole(string username, int RoleID)
        {
            try
            {
                _roleBLL.AddUserToRole(username, RoleID);
                return Ok("Role added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
