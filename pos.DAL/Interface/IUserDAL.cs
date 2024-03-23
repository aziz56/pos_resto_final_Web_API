using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using pos.BO;

namespace pos.DAL.Interface
{
    public interface IUserDAL :  ICrud<User>
    {
        IEnumerable<User> GetAllWithRoles();
        User GetByUsername(string username);
        User Login(string username, string password);
        void ChangePassword(string username, string newPassword);

    }
}
