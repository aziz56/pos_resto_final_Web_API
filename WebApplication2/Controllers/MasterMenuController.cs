using Microsoft.AspNetCore.Http;
using pos.BLL;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterMenuController : ControllerBase
    {
        private readonly MasterMenuBLL _masterMenuBLL;
        [Route("api/[controller]")]

        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _masterMenuBLL.GetAll();
            return Ok(data);
        }
            

    }
}
