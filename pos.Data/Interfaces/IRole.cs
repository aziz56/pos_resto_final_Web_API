using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using posServices.Domain.Models;

namespace posServices.Data.Interfaces
{
    public interface IRole
    {
        Task<Task> AddUserToRole(string username, int roleId);
        Task<IEnumerable<Role>> GetAllRoles();

    }
}
