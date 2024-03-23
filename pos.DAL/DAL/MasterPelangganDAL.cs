using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Transactions;
using Dapper;
using pos.BO;
using pos.DAL.Interface;

namespace pos.DAL.DAL
{
    public class MasterPelangganDAL : IMasterPelanggan
    {
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["pos_restoConnectionString"].ConnectionString;
        }
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"delete from MasterPelanggan where id_pelanggan=@id_pelanggan";
                var param = new { id_pelanggan = id };
                conn.Execute(strSql, param);
            }
        }

        public IEnumerable<MasterPelanggan> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"select * from MasterPelanggan";
                var results = conn.Query<MasterPelanggan>(strSql);
                return results;
            }
        }

        public MasterPelanggan GetByID(int id)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    string strSql = @"select * from MasterPelanggan where id_pelanggan=@id_pelanggan";
                    var param = new { id_pelanggan = id };
                    var result = conn.QuerySingleOrDefault<MasterPelanggan>(strSql, param);
                    return result;

                }

            }

        }


        void ICrud<MasterPelanggan>.Insert(MasterPelanggan entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    string strSql = @"insert into MasterPelanggan(nama_pelanggan, no_telp_pelanggan, email_pelanggan ) values(@nama_pelanggan,@no_telp_pelanggan,@email_pelanggan)";
                    var param = new
                    {
                        nama_pelanggan = entity.nama_pelanggan,
                        no_telp_pelanggan = entity.no_telp_pelanggan,
                        email_pelanggan = entity.email_pelanggan

                    };
                    connection.Execute(strSql, param);
                }
                scope.Complete();
            }
        }


        void ICrud<MasterPelanggan>.Update(MasterPelanggan entity)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    string strSql = @"update MasterPelanggan set nama_pelanggan=@nama_pelanggan, no_telp_pelanggan=@no_telp_pelanggan, email_pelanggan=@email_pelanggan where id_pelanggan=@id_pelanggan";
                    var param = new
                    {
                        id_pelanggan = entity.id_pelanggan,
                        nama_pelanggan = entity.nama_pelanggan,
                        no_telp_pelanggan = entity.no_telp_pelanggan,
                        email_pelanggan = entity.email_pelanggan
                    };
                    connection.Execute(strSql, param);
                }
                scope.Complete();
            }
        }
    }
}




