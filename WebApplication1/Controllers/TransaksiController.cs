using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using pos.BLL;
using pos.BLL.DTO;
using pos.BLL.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;


namespace WebApplication1.Controllers

{
    
    public class TransaksiController : Controller
    {
        
        private readonly ITransaksiBLL _transaksiBLL;
        private readonly IMasterMenuBLL _masterMenu;
        public TransaksiController(ITransaksiBLL transaksiBLL, IMasterMenuBLL masterMenu)
        {
            _masterMenu = masterMenu;
            _transaksiBLL = transaksiBLL;
        }



        public IActionResult Index(TransactionDataDTO transactionDataDTO, MasterMenuDTO masterMenuDTO)
        {
            //var allMenu = _masterMenu.GetAll().ToList();
            //var listMenu= new SelectList(allMenu, "id_menu","nama_menu", "harga_menu");
            //ViewBag.listMenu = listMenu;
            //var hargaMenu = _transaksiBLL.GetHargaByMenu(masterMenuDTO);
            //transactionDataDTO.harga_menu = hargaMenu.harga_menu;   
            var allTransaksi = _transaksiBLL.GetTransaksiPenjualan();
            ViewBag.allTransaksi = allTransaksi;
             //_transaksiBLL.InsertPayment(transactionDataDTO);
            return View(allTransaksi);

        }
        public IActionResult Create()
        {
            var allMenu = _masterMenu.GetAll().ToList();
            var listMenu = new SelectList(allMenu, "id_menu", "nama_menu","harga_menu");
            ViewBag.listMenu = listMenu;
            return View();
        }
        [HttpPost]
        public IActionResult Create(TransactionCreateDTO transactionCreateDTO)
        {
            var hargaMenu = _transaksiBLL.GetHargaByMenu(new MasterMenuDTO { id_menu = transactionCreateDTO.id_menu });
            transactionCreateDTO.harga_menu = hargaMenu.harga_menu;
            _transaksiBLL.InsertPayment(transactionCreateDTO);
            return RedirectToAction("Index");
        }
        //[HttpGet]
        //public IActionResult GetMenuPrice(int id_menu)
        //{
        //    var hargaMenu = _transaksiBLL.GetHargaByMenu(new MasterMenuDTO { id_menu = id_menu });
        //    return Json(new { price = hargaMenu.harga_menu });
        //}





    }
}
