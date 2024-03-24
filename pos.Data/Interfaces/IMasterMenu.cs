using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using posServices.Domain.Models;
namespace posServices.Data.Interfaces
{
    public interface IMasterMenu : ICrudData<MasterMenu>
    {
        //GetHargaById
        Task<MasterMenu> GetHargaById(int id);

    }
}
