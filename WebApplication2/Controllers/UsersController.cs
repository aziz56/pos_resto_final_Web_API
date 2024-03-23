//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using pos.BLL.Interface;
//using pos.BLL.DTO;
//using pos.BLL;

//namespace WebApplication2.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UsersController : ControllerBase
//    {
//        private readonly IUserBLL _userBLL;
//        private readonly IRoleBLL _roleBLL;
//        public UsersController(IUserBLL userBLL, IRoleBLL roleBLL)
//        {
//            _userBLL = userBLL;
//            _roleBLL = roleBLL;
//            _roleBLL = roleBLL;
//        }
//        [HttpPost]
//        public IActionResult Insert(UserCreateDTO userCreateDTO)
//        {
//            try
//            {
//                _userBLL.Insert(userCreateDTO);
//                return Ok("User added successfully");
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }
//        [HttpPost]
//        public IActionResult Login(string name, string password)
//        {
//            try
//            {
//                var user = _userBLL.Login(name, password);
//                return Ok(user);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }
//        public IActionResult GetAll()
//        {
//            try
//            {
//                var users = _userBLL.GetAll();
//                return Ok(users);
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }
//        [HttpPost]
//        public IActionResult AddUserToRole(string username, int RoleID)
//        {
//            try
//            {
//                _roleBLL.AddUserToRole(username, RoleID);
//                return Ok("Role added successfully");
//            }
//            catch (Exception ex)
//            {
//                return BadRequest(ex.Message);
//            }
//        }


//    }
//}
