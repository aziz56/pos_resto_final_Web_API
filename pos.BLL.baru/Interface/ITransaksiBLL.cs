using System;
using System.Collections.Generic;
using System.Text;
using pos.BLL.DTO;


namespace pos.BLL.Interface
{
    public interface ITransaksiBLL
    {
        void InsertPayment(DTO.TransactionCreateDTO transactionCreateDTO);

        MasterMenuDTO GetHargaByMenu(DTO.MasterMenuDTO masterMenuDto);
        IEnumerable<TransactionDataDTO> GetTransaksiPenjualan();


    }
}
