using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using posServices.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace posServices.Data
{
    public class MasterMenuData
    {
        private readonly AppDbContext _context;
        public MasterMenuData(AppDbContext context)
        {
            _context = context;
        }
        //GetAll
        public async Task<IEnumerable<MasterMenu>> GetAll()
        {
           var result = await _context.MasterMenus.ToListAsync();
            return result;
            
        }
        public async Task<MasterMenu> Insert(MasterMenu entity)
        {
            try
            {
                _context.MasterMenus.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<MasterMenu> Update(int id, MasterMenu entity)
        {
            try
            {
                var menu = await _context.MasterMenus.FirstOrDefaultAsync(m => m.IdMenu == id);
                if (menu == null)
                {
                    throw new ArgumentException("Menu not found");
                }
                menu.NamaMenu = entity.NamaMenu;
                menu.DeskripsiMenu = entity.DeskripsiMenu;
                menu.HargaMenu = entity.HargaMenu;
                await _context.SaveChangesAsync();
                return menu;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var menu = await _context.MasterMenus.FirstOrDefaultAsync(m => m.IdMenu == id);
                if (menu == null)
                {
                    throw new ArgumentException("Menu not found");
                }
                _context.MasterMenus.Remove(menu);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<MasterMenu> GetById(int id)
        {
            var menu = await _context.MasterMenus.FirstOrDefaultAsync(m => m.IdMenu == id);
            if (menu == null)
            {
                throw new ArgumentException("Menu not found");
            }
            return menu;
        }


    }
}
