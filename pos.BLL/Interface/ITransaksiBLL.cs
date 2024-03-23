using System;
using System.Collections.Generic;
using System.Text;
using pos.BO;

namespace pos.BLL.Interface
{
    public interface ITransaksiBLL
    {
        void InsertPayment(DTO.TransaksiPenjualanDTO transaksiPenjualanDTO);

    }
}
