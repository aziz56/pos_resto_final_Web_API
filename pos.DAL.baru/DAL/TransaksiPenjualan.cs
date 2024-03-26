using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pos.DAL.Interface;
using Dapper;
using pos.BO;
using System.Data;

namespace pos.DAL.DAL
{
    public class TransaksiPenjualan: ITransaksiPenjualan
    {
        private string GetConnectionString()
        {
            return Helper.GetConnectionString();
        }
        public void InsertPayment(TransactionData transactionData)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = "sp_Penjualan";
                var param = new DynamicParameters();
                param.Add("@nama_pelanggan", transactionData.nama_pelanggan);
                param.Add("@jumlah_pesanan", transactionData.jumlah_pesanan);
                param.Add("@harga_menu", transactionData.harga_menu);
                param.Add("@amount", transactionData.amount);
                param.Add("@id_menu", transactionData.id_menu);
                param.Add("@id_meja", transactionData.id_meja);
                param.Add("@id_penjualan", dbType: DbType.Int32, direction: ParameterDirection.Output);

                conn.Execute(strSql, param, commandType: CommandType.StoredProcedure);

                // Retrieve the value of the output parameter
                int id_penjualan = param.Get<int>("@id_penjualan");
                // Use the idPenjualan value as needed
            }
        }

        public MasterMenu GetHargaByMenu(BO.MasterMenu masterMenu)
        {
            using SqlConnection conn = new SqlConnection(GetConnectionString());
            string strSql = @"select harga_menu from MasterMenu where id_menu = @id_menu";
            var param = new { id_menu = masterMenu.id_menu };
            var result = conn.QueryFirstOrDefault<BO.MasterMenu>(strSql, param);
            return result;
        }
        public IEnumerable<TransactionData> GetTransaksiPenjualan()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"GetTransactionData";
                var results = conn.Query<BO.TransactionData>(strSql);
                return results;
            }
        }
        IEnumerable<BO.TransaksiPenjualan> ICrud<BO.TransaksiPenjualan>.GetAll()
        {
            throw new NotImplementedException();
        }

        BO.TransaksiPenjualan ICrud<BO.TransaksiPenjualan>.GetByID(int id)
        {
            throw new NotImplementedException();
        }

        void ICrud<BO.TransaksiPenjualan>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        void ICrud<BO.TransaksiPenjualan>.Insert(BO.TransaksiPenjualan entity)
        {
            throw new NotImplementedException();
        }

        void ICrud<BO.TransaksiPenjualan>.Update(BO.TransaksiPenjualan entity)
        {
            throw new NotImplementedException();
        }

        
    }
}
