using System;
using System.Collections.Generic;
using System.Text;
using pos.BLL.DTO;

namespace pos.BLL.Interface
{
    public interface IUserBLL 
    {
        UserDTO Login(string name, string password);
        void Insert(UserCreateDTO entity);
        IEnumerable<UserDTO> GetAll();
        void Delete(string name);
        void ChangePassword(string name, string newPassword);

    }
}
