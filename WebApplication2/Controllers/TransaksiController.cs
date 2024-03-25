using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pos.BLL;
using pos.BLL.DTO;
using pos.BLL.Interface;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaksiController : ControllerBase
    {
        private readonly ITransaksiBLL _transaksiBLL;
        public TransaksiController(ITransaksiBLL transaksiBLL)
        {
            _transaksiBLL = transaksiBLL;
        }

        [HttpGet("GetTransaksi")]
        public IActionResult GetTransaksi()
        {
            try
            {
                var result = _transaksiBLL.GetTransaksiPenjualan();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("InsertTransaksi")]
        public IActionResult InsertTransaksi([FromBody] TransactionCreateDTO transaction)
        {
            try
            {
                _transaksiBLL.InsertPayment(transaction);
                    return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet]


    }
}
