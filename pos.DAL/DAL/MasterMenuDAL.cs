using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using pos.BO;   
using pos.DAL.Interface;

namespace pos.DAL.DAL
{
    public class MasterMenuDAL : IMasterMenu
    {
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["pos_restoConnectionString"].ConnectionString;
        }
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"delete from MasterMenu where id_menu=@id_menu";
                var param = new { id_menu = id };
                conn.Execute(strSql, param);
            }
        }
        public UserDAL GetByID(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"select * from MasterMenu where id_menu=@id_menu";
                var param = new { id_menu = id };
                var data = conn.QueryFirstOrDefault<UserDAL>(strSql, param);
                return data;
            }
        }
        public IEnumerable<MasterMenu> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"select * from MasterMenu";
                var data = conn.Query<MasterMenu>(strSql);
                return data;
            }
        }
        public void Insert(MasterMenu entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"insert into MasterMenu (id_menu, nama_menu, harga, kategori, deskripsi, gambar) values (@id_menu, @nama_menu, @harga, @kategori, @deskripsi, @gambar)";
                var param = new { id_menu = entity.id_menu, entity.nama_menu, entity.harga_menu, entity.deskripsi_menu };
                conn.Execute(strSql, param);
            }
        }
        public void Update(MasterMenu entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"update MasterMenu set nama_menu=@nama_menu, harga=@harga, kategori=@kategori, deskripsi=@deskripsi, gambar=@gambar where id_menu=@id_menu";
                var param = new { entity.nama_menu, entity.harga_menu, entity.deskripsi_menu, entity.id_menu };
                conn.Execute(strSql, param);
            }
        }
        public void Delete(MasterMenu entity)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"delete from MasterMenu where id_menu=@id_menu";
                var param = new { entity.id_menu };
                conn.Execute(strSql, param);
            }
        }

        MasterMenu IMasterMenu.GetById(int id)
        {
           using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"select * from MasterMenu where id_menu=@id_menu";
                var param = new { id_menu = id };
                var data = conn.QueryFirstOrDefault<MasterMenu>(strSql, param);
                return data;
            }
        }

        IEnumerable<MasterMenu> IMasterMenu.GetByName(string name)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"select * from MasterMenu where nama_menu like @nama_menu";
                var param = new { nama_menu = "%" + name + "%" };
                var data = conn.Query<MasterMenu>(strSql, param);
                return data;
            }   
      
        }


        MasterMenu ICrud<MasterMenu>.GetByID(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"select * from MasterMenu where id_menu=@id_menu";
                var param = new { id_menu = id };
                var data = conn.QueryFirstOrDefault<MasterMenu>(strSql, param);
                return data;
            }
            
        }
        public IEnumerable<MasterMenu> GetWithPaging(int pageNumber, int pageSize, string name)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"select * from Categories 
                               where CategoryName like @CategoryName 
                               order by CategoryName OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";
                var param = new { nama_menu = $"%{name}%", Offset = (pageNumber - 1) * pageSize, PageSize = pageSize };
                var results = conn.Query<MasterMenu>(strSql, param);
                return results;
            }
        }
        public int GetCountMenu(string name)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"select count(*) from MasterMenu where nama_menu like @nama_menu";
                var param = new { nama_menu = $"%{name}%" };
                var count = conn.ExecuteScalar<int>(strSql, param);
                return count;
            }
        }

        




    }
}
