using Microsoft.AspNetCore.Mvc;
using pos.BLL.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using pos.BLL.DTO;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers
{
    //[Authorize(Policy = "OwnerPolicy")]
    public class UsersController : Controller
        
    {
        private readonly IUserBLL _userBLL;
        private readonly IRoleBLL _roleBLL;
        public UsersController(IUserBLL userBLL, IRoleBLL roleBLL)
        {
            _userBLL = userBLL;
            _roleBLL = roleBLL;
        }
        public IActionResult Index()
        {
            if (TempData["message"] != null)
            {
                ViewBag.Message = TempData["message"].ToString();
            }
            var users = _userBLL.GetAll();
            var listUsers = new SelectList(users, "Username", "Username");
            ViewBag.Users = listUsers;

            var roles = _roleBLL.GetAllRoles();
            var listRoles = new SelectList(roles, "RoleID", "RoleName");
            ViewBag.Roles = listRoles;

            var usersWithRoles = _userBLL.GetAllWithRoles();
            return View(usersWithRoles);
        }
        [HttpPost]
        public IActionResult Index(string username, int RoleID)
        {
            try
            {
                _roleBLL.AddUserToRole(username, RoleID);
                TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong> Role added successfully!</div>";
            }
            catch (Exception ex)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong> " + ex.Message + "</div>";
            }
            return RedirectToAction("Index");
        }
        public IActionResult Login()
        {
            if (TempData["message"] != null)
            {
                ViewBag.Message = TempData["message"].ToString();
            }
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                var userDto = _userBLL.LoginMVC(loginDTO);
                //simpan username ke session
                var userDtoSerialize  = JsonSerializer.Serialize(userDto);
                HttpContext.Session.SetString("user", userDtoSerialize);

                TempData["Message"] = "Welcome " + userDto.Username;
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Message = @"<div class='alert alert-danger'><strong>Error!&nbsp;</strong>" + ex.Message + "</div>";
                return View();
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login","Users");
        }
        public IActionResult Register()
        {
            if (TempData["message"] != null)
            {
                ViewBag.Message = TempData["message"].ToString();
            }
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserCreateDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _userBLL.Insert(userDTO);
                TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong> User added successfully!</div>";
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                ViewBag.Message = @"<div class='alert alert-danger'><strong>Error!&nbsp;</strong>" + ex.Message + "</div>";
                return View();
            }
        }
        public IActionResult Profile()
        {
            var usersWithRoles = _userBLL.GetUserWithRoles(User.Identity.Name);
            return new JsonResult(usersWithRoles);
        }




    }
}
