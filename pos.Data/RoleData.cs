using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using posServices.Data.Interfaces;
using posServices.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace posServices.Data
{
    public class RoleData : IRole


    {
        private readonly AppDbContext _context;
        public RoleData(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Task> AddUserToRole(string username, int roleId)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
                if (user == null)
                {
                    throw new ArgumentException("User not found");
                }
                var role = await _context.Roles.FirstOrDefaultAsync(r => r.RoleId == roleId);
                if (role == null)
                {    
                    throw new ArgumentException("Role not found");
                }
                role.Usernames.Add(user);
                await _context.SaveChangesAsync();
                return Task.CompletedTask;
            
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
     
        }
        public async Task<IEnumerable<Role>> GetAllRoles()
        {
            try
            {
                var roles = await _context.Roles.ToListAsync();
                return roles;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }       
            }

        }


    }

