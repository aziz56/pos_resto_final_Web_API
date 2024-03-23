//using System;
//using System.Collections.Generic;
//using System.Text;
//using pos.BLL.DTO;

//namespace pos.BLL
//{
//    public class TransaksiPenjualanBLL
//    {
//        private readonly DAL.Interface.ITransaksiPenjualan _transaksiPenjualan;

//        public TransaksiPenjualanBLL()
//        {
//            _transaksiPenjualan = new DAL.DAL.TransaksiPenjualan();
//        }
//        public void InsertPayment(TransaksiPenjualanDTO transaksiPenjualanDTO)
//        {
                
//            var transaksiPenjualan = new BO.TransaksiPenjualan()
//            {
//                nama_pelanggan = transaksiPenjualanDTO.nama_pelanggan,
//                no_meja = transaksiPenjualanDTO.no_meja,
//                jumlah_pesanan = transaksiPenjualanDTO.jumlah_pesanan,
//                harga_menu = transaksiPenjualanDTO.harga_menu,
//                nama_menu = transaksiPenjualanDTO.nama_menu,
//                amount = transaksiPenjualanDTO.amount

//            };
//            _transaksiPenjualan.InsertPayment(transaksiPenjualan);

//        }


//    }
//}
