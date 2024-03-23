using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pos.BLL.Interface;
using pos.BLL.DTO;
using System.Text.Json;

using System.Reflection;
using Microsoft.AspNetCore.Authorization;


namespace pos_resto.Controllers
{
    //[Authorize(Policy = "OwnerPolicy")]
    public class MasterMenuController : Controller
    {
        private readonly IMasterMenuBLL _masterMenu;
        public MasterMenuController(IMasterMenuBLL masterMenu)
        {
            _masterMenu = masterMenu;
        }
        [HttpGet]
        //public IEnumerable<MasterMenuDTO>GetAll()
        //{
        //    try
        //    {
        //     _masterMenu.GetAll();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return _masterMenu.GetAll();

        //}
        //public IActionResult GetById(int id)
        //{
        //    try
        //    {
        //        _masterMenu.GetById(id);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    return View();
        //}
        // GET: MasterMenuController
        public IActionResult Index(string search="", int pageNumber = 1, int pageSize = 5, string act = "")
        {
            //if (HttpContext.Session.GetString("role") == null)
            //{
            //    // Handle the case where user is not logged in
            //    TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong> Anda harus login terlebih dahulu!</div>";
            //    return RedirectToAction("Index", "Login");
            //}

            //var user = JsonSerializer.Deserialize<UserDTO>(HttpContext.Session.GetString("user"));
            //if (!Auth.CheckRole("reader,admin,contributor", user.Roles.ToList()))
            //{
            //    TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong> Anda tidak memiliki hak akses!</div>";
            //    return RedirectToAction("Index", "Home");
            //}

            if (TempData["message"] != null)
            {
                ViewBag.Message = TempData["message"];
            }

            ViewData["search"] = search;
            
            var cari = _masterMenu.GetByName(search);
            var models = _masterMenu.GetWithPaging(pageNumber, pageSize, search);
            var maxsize = _masterMenu.GetCountMenu(search);

            if (act == "next")
            {
                if (pageNumber * pageSize < maxsize)
                {
                    pageNumber += 1;
                }
                ViewData["pageNumber"] = pageNumber;
            }
            else if (act == "prev")
            {
                if (pageNumber > 1)
                {
                    pageNumber -= 1;
                }
                ViewData["pageNumber"] = pageNumber;
            }
            else
            {
                ViewData["pageNumber"] = 2;
            }

            ViewData["pageSize"] = pageSize;

            return View(models);
        }


        //var models = _masterMenu.GetAll();
        //return View(models);

        // GET: MasterMenuController/Details/5
        public IActionResult Details(int id)
        {
            try
            {
                var model = _masterMenu.GetById(id);
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MasterMenuDTO masterMenuDTO)
        {
            try
            {
                _masterMenu.Insert(masterMenuDTO);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return RedirectToAction("Index");
        }

        // POST: MasterMenuController/Create
 

        // GET: MasterMenuController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _masterMenu.GetById(id);
            if (model == null)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Data tidak ditemukan !</div>";
                return RedirectToAction("Index");
            }
            return View(model);
        }


        // POST: MasterMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, MasterMenuDTO masterMenuDTO)
        {
            try
            {
                _masterMenu.Update(masterMenuDTO);
                TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Data berhasil diubah !</div>";
            }
            catch
            {
                ViewData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Data gagal diubah !</div>";
                return View(masterMenuDTO);
            }
            return RedirectToAction("Index");
        }

        // GET: MasterMenuController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                _masterMenu.Delete(id);
                TempData["message"] = @"<div class='alert alert-success'><strong>Success!</strong>Data berhasil dihapus !</div>";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["message"] = @"<div class='alert alert-danger'><strong>Error!</strong>Data gagal dihapus !</div>";
                return RedirectToAction("Index");
            }

            }
        }

        // POST: MasterMenuController/Delete/5
 
    }
