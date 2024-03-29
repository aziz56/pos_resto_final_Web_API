using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using posServices.BLL.Interfaces;
using posServices.Domain.Models;
using posServices.BLL;



namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaksiFromEFController : ControllerBase
    {
        private readonly ITransaksiPenjualanBLL _transaksiPenjualan;
        public TransaksiFromEFController(ITransaksiPenjualanBLL transaksiPenjualan)
        {
            _transaksiPenjualan = transaksiPenjualan;
        }
        [HttpGet("GetAllTransaksiAndDetail")]
        public async Task<IActionResult> GetAllTransaksiPenjualanAndTransaksiDetailPenjualan()
        {
            try
            {
                var result = await _transaksiPenjualan.GetAllTransaksiPenjualanAndTransaksiDetailPenjualan();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{namaPelanggan}")]
        public async Task<IActionResult> GetTransaksiByPelanggan(string namaPelanggan)
        {
            try
            {
                var result = await _transaksiPenjualan.GetTransaksiByPelanggan(namaPelanggan);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("InsertPaymentWithInvoice")]
        public async Task<IActionResult> InsertPenjualanWithInvoice(string namaPelanggan, List<(int IdMenu, int JumlahPesanan)> pesananList, int idMeja, decimal amount)
        {
            try
            {
                await _transaksiPenjualan.InsertPenjualanWithInvoice(namaPelanggan, pesananList, idMeja, amount);
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("InsertTransaksiReservasi")]
        public async Task<IActionResult> InsertTransaksiReservasi(string NamaPelanggan, int IdMeja, DateTime TanggalReservasi, TimeOnly JamReservasi)
        {
            try
            {
                await _transaksiPenjualan.InsertTransaksiReservasi(NamaPelanggan, IdMeja, TanggalReservasi, JamReservasi);
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("InsertTransaksiReservasi2")]
       public async Task<IActionResult> InsertTransaksiReservasi(List<TransaksiDetailReservasi> detailReservasi, string NamaPelanggan, DateTime TanggalReservasi, TimeOnly JamReservasi)
        {
            try
            {
                await _transaksiPenjualan.InsertTransaksiReservasi(detailReservasi, NamaPelanggan, TanggalReservasi, JamReservasi);
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllReservasi")]
        public async Task<IActionResult> GetAllTransaksiReservasi()
        {
            try
            {
                var result = await _transaksiPenjualan.GetAllTransaksiReservasi();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetCountTotalTransaction")]
        public async Task<IActionResult> GetCountTotalTransaction()
        {
            try
            {
                var result = await _transaksiPenjualan.GetCountTotalTransaction();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetCountTotalTransactionByDate")]
        public async Task<IActionResult> GetCountTotalTransactionByDate(DateOnly date)
        {
            try
            {
                var result = await _transaksiPenjualan.GetCountTotalTransactionByDate(date);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetTop5MenuByTransaction")]

        public async Task<IActionResult> GetTop5MenuByTransaction()
        {
            try
            {
                var result = await _transaksiPenjualan.GetTop5MenuByTransaction();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetTotalTransactionByMenu")]
        public async Task<IActionResult> GetTotalTransactionByMenu(string namaMenu)
        {
            try
            {
                var result = await _transaksiPenjualan.GetTotalTransactionByMenu(namaMenu);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetTotalTransactionByPelanggan")]
        public async Task<IActionResult> GetTotalTransactionByPelanggan(string namaPelanggan)
        {
            try
            {
                var result = await _transaksiPenjualan.GetTotalTransactionByPelanggan(namaPelanggan);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetTotalBalanceByDate")]
        public async Task<IActionResult> GetTotalBalanceByDate(DateOnly date)
        {
            try
            {
                var result = await _transaksiPenjualan.GetTotalBalanceByDate(date);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetTotalBalance")]
        public async Task<IActionResult> GetTotalBalance()
        {
            try
            {
                var result = await _transaksiPenjualan.GetTotalBalance();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetHargaMenuById")]
        public async Task<IActionResult> GetHargaMenuById(int idMenu)
        {
            try
            {
                var result = await _transaksiPenjualan.GetHargaMenuById(idMenu);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAllTransaksiPenjualan")]
        public async Task<IActionResult> GetAllTransaksiPenjualan()
        {
            try
            {
                var result = await _transaksiPenjualan.GetAllTransaksiPenjualan();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
