using System;
using System.Collections.Generic;
using System.Text;
using pos.BLL.DTO;
using pos.BLL.Interface;
using pos.DAL.Interface;
using pos.DALnew.DAL;


namespace pos.BLL
{
    public class MasterMenuBLL:IMasterMenuBLL
    {
        private readonly IMasterMenu _masterMenuDAL;
        public MasterMenuBLL()
        {
            _masterMenuDAL = new MasterMenuDAL();
        }
        public void Delete(int id)
        {
            _masterMenuDAL.Delete(id);
        }
        
        public void Insert(MasterMenuDTO entity)
        {
            try { 
            var masterMenu = new pos.BO.MasterMenu
            {
                nama_menu = entity.nama_menu,
                harga_menu = entity.harga_menu,
                deskripsi_menu = entity.deskripsi_menu
            };
                _masterMenuDAL.Insert(masterMenu);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<MasterMenuDTO> GetAll()
        {
            List<MasterMenuDTO> masterMenuDTOs = new List<MasterMenuDTO>();
            var masterMenu = _masterMenuDAL.GetAll();
            foreach (var item in masterMenu)
            {
                masterMenuDTOs.Add(new MasterMenuDTO
                {
                    id_menu = item.id_menu,
                    nama_menu = item.nama_menu,
                    harga_menu = item.harga_menu,
                    deskripsi_menu = item.deskripsi_menu

                });

            }
            return masterMenuDTOs;

            
        }
        public MasterMenuDTO GetById(int id)
        {
            var masterMenu = _masterMenuDAL.GetByID(id);
            var masterMenuDTO = new MasterMenuDTO
            {
                id_menu = masterMenu.id_menu,
                nama_menu = masterMenu.nama_menu,
                harga_menu = masterMenu.harga_menu,
                deskripsi_menu = masterMenu.deskripsi_menu
            };
            return masterMenuDTO;
        }

       public void Update(MasterMenuDTO entity)
        {
            var masterMenu = new pos.BO.MasterMenu
            {
                id_menu = entity.id_menu,
                nama_menu = entity.nama_menu,
                harga_menu = entity.harga_menu,
                deskripsi_menu = entity.deskripsi_menu
            };
            _masterMenuDAL.Update(masterMenu);
            
        }

       public int GetCountMenu(string name)
        { try
            {
                return _masterMenuDAL.GetCountMenu(name);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

        public IEnumerable<MasterMenuDTO> GetByName(string name)
        {
           pos.BO.MasterMenu masterMenu = new pos.BO.MasterMenu();
            var masterMenuDTOs = new List<MasterMenuDTO>();
            var masterMenuDAL = _masterMenuDAL.GetByName(name);
            foreach (var item in masterMenuDAL)
            {
                masterMenuDTOs.Add(new MasterMenuDTO
                {
                    id_menu = item.id_menu,
                    nama_menu = item.nama_menu,
                    harga_menu = item.harga_menu,
                    deskripsi_menu = item.deskripsi_menu
                });
            }
            return masterMenuDTOs;
        }

        public IEnumerable<MasterMenuDTO> GetWithPaging(int pageNumber, int pageSize, string name)
        {
            pos.BO.MasterMenu masterMenu = new pos.BO.MasterMenu();
            var masterMenuDTOs = new List<MasterMenuDTO>();
            var masterMenuDAL = _masterMenuDAL.GetWithPaging(pageNumber, pageSize, name);
            foreach (var item in masterMenuDAL)
            {
                masterMenuDTOs.Add(new MasterMenuDTO
                {
                    id_menu = item.id_menu,
                    nama_menu = item.nama_menu,
                    harga_menu = item.harga_menu,
                    deskripsi_menu = item.deskripsi_menu
                });
            }
            return masterMenuDTOs;
            
        }
    }
}
