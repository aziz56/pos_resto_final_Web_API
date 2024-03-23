using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pos.DAL.Interface
{
    public interface IRole: ICrud<pos.BO.Roles>
    {
        void AddUserToRole(string username, int roleId);
    }
}
