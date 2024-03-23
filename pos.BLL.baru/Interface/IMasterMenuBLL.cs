using System;
using System.Collections.Generic;
using System.Text;
using pos.BLL.DTO;

namespace pos.BLL.Interface
{
    public interface IMasterMenuBLL
    {
        void Delete(int id);
        void Insert(MasterMenuDTO entity);
        IEnumerable<MasterMenuDTO> GetAll();
        MasterMenuDTO GetById(int id);
        void Update(MasterMenuDTO entity);
        int GetCountMenu(string name);
        IEnumerable<MasterMenuDTO> GetByName(string name);
        IEnumerable<MasterMenuDTO> GetWithPaging(int pageNumber, int pageSize, string name);



    }
}
