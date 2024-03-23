using System;
using System.Collections.Generic;
using System.Text;
using pos.BO;

namespace pos.DAL.Interface
{
    public interface IMasterMenu:ICrud<MasterMenu>
    {
        //MasterMenu GetById(int id);
        IEnumerable<MasterMenu> GetByName(string name);
        IEnumerable<MasterMenu> GetWithPaging(int pageNumber, int pageSize, string name);

        int GetCountMenu(string name);





    }
}
