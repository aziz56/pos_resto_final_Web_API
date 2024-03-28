using Microsoft.AspNetCore.Http;
using pos.BLL;
using pos.BLL.DTO;
using Microsoft.AspNetCore.Mvc;
using pos.BLL.Interface;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication2.Controllers
{
    //[Authorize(Roles = "Owner")]
    [Route("api/[controller]")]
    [ApiController]
    public class MasterMenuController : ControllerBase
    {
        private readonly IMasterMenuBLL _masterMenuBLL;
        public MasterMenuController(IMasterMenuBLL masterMenuBLL)
        {
            _masterMenuBLL = masterMenuBLL;
        }
     
        [HttpGet]
        // GET: MasterMenuController
        public IActionResult GetallMenu()
        {
          
            return Ok(_masterMenuBLL.GetAll());
        }
   
      
        [HttpPost]
        // POST: MasterMenuController/Create
        public IActionResult Create([FromBody] MasterMenuDTO masterMenuDTO)
        {
            _masterMenuBLL.Insert(masterMenuDTO);
            return Ok();
        }
        [HttpPut("{id}")]
        // PUT: MasterMenuController/Edit/5
        public IActionResult Edit([FromBody] MasterMenuDTO masterMenuDTO)
        {
            _masterMenuBLL.Update(masterMenuDTO);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _masterMenuBLL.Delete(id);
            return Ok();
        }

            

    }
}
