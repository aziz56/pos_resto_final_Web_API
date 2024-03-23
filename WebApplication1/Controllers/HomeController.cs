using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using pos.BLL.Interface;
using pos.BLL.DTO;
using System.Text.Json;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserBLL _userBLL;
        private readonly IRoleBLL _roleBLL;



        public IActionResult Index()
        {

            //cek kalau session ada
            if (HttpContext.Session.GetString("user") == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong> You must login first !</div>";
                return RedirectToAction("Login", "Users");
            }
            else
            {
                var user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
                ViewBag.message = $"Welcome {user.Username}";
            }
            return View();

        }

 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
