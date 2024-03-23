using System;
using System.Collections.Generic;
using System.Text;
using pos.BO;

namespace pos.DAL.Interface
{
    public interface ITransaksiPenjualan : ICrud<TransaksiPenjualan>
    {
        void InsertPayment(TransactionData TransactionData);
        MasterMenu GetHargaByMenu(BO.MasterMenu masterMenu);
        IEnumerable<TransactionData> GetTransaksiPenjualan();


    }
}
