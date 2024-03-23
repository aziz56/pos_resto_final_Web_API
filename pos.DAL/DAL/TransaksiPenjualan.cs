//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data.SqlClient;
//using System.Data.SqlTypes;
//using System.Text;
//using pos.DAL.Interface;
//using pos.BO;
//using Dapper;
//using System.Security.Cryptography.X509Certificates;

//namespace pos.DAL.DAL
//{
//    public class TransaksiPenjualan : ITransaksiPenjualan
//    {
//        private string GetConnectionString()
//        {
//            return ConfigurationManager.ConnectionStrings["pos_restoConnectionString"].ConnectionString;
//        }
//        public void InsertPayment(BO.TransaksiPenjualan transaksiPenjualan)
//        {
//            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
//            {
//                string strSql = @"sp_penjualan";
//                var param = new
//                {
//                    nama_pelanggan = transaksiPenjualan.nama_pelanggan,
//                    no_meja = transaksiPenjualan.no_meja,
//                    jumlah_pesanan = transaksiPenjualan.jumlah_pesanan,
//                    harga_menu = transaksiPenjualan.harga_menu,
//                    nama_menu = transaksiPenjualan.nama_menu,
//                    amount = transaksiPenjualan.amount


//                };
//                conn.Execute(strSql, param, commandType: System.Data.CommandType.StoredProcedure);
//            }
//        }

//        void ITransaksiPenjualan.GetHargaByMenu(BO.TransaksiPenjualan transaksiPenjualan)
//        {
//            throw new NotImplementedException();
//        }

//        IEnumerable<BO.TransaksiPenjualan> ICrud<BO.TransaksiPenjualan>.GetAll()
//        {
//            throw new NotImplementedException();
//        }

//        BO.TransaksiPenjualan ICrud<BO.TransaksiPenjualan>.GetByID(int id)
//        {
//            throw new NotImplementedException();
//        }

//        void ICrud<BO.TransaksiPenjualan>.Delete(int id)
//        {
//            throw new NotImplementedException();
//        }

//        void ICrud<BO.TransaksiPenjualan>.Insert(BO.TransaksiPenjualan entity)
//        {
//            throw new NotImplementedException();
//        }

//        void ICrud<BO.TransaksiPenjualan>.Update(BO.TransaksiPenjualan entity)
//        {
//            throw new NotImplementedException();
//        }
//    }


//}

