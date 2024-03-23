using System.Data.SqlClient;
using pos.BO;   
using pos.DAL.Interface;
using Dapper;
using pos.DAL.DAL;

using System.Data;
using Microsoft.Extensions.Configuration;


namespace pos.DALnew.DAL
{
    public class MasterMenuDAL : IMasterMenu
    {
        //private string GetConnectionString()
        //{
        //     return Helper.GetConnectionString();
        //}
        public static string GetConnectionString()
        {
            if (System.Configuration.ConfigurationManager.ConnectionStrings["pos_restoConnectionString"] == null)
            {
                var MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                return MyConfig.GetConnectionString("pos_restoConnectionString");
            }
            var connString = System.Configuration.ConfigurationManager.ConnectionStrings["pos_restoConnectionString"].ConnectionString;
            return connString;

            //public static string GetConnectionString()
            //{
            //        IConfigurationRoot configuration = new ConfigurationBuilder()
            //        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            //        .AddJsonFile("appsettings.json")
            //        .Build();

            //    return configuration.GetConnectionString("pos_restoConnectionString");
            //}

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
        //public UserDAL GetByID(int id)
        //{
        //    using (SqlConnection conn = new SqlConnection(GetConnectionString()))
        //    {
        //        string strSql = @"select * from MasterMenu where id_menu=@id_menu";
        //        var param = new { id_menu = id };
        //        var data = conn.QueryFirstOrDefault<UserDAL>(strSql, param);
        //        return data;
        //    }
        //}


public IEnumerable<MasterMenu> GetAll()
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"sp_GetAllMenu";
                var results = conn.Query<MasterMenu>(strSql, commandType: System.Data.CommandType.StoredProcedure);
                return results;
            }
        }
        catch (Exception ex)
        {
            // Log or handle the exception as per your application's requirements
            Console.WriteLine($"An error occurred while retrieving all menu items: {ex.Message}");
            throw; // Re-throw the exception to propagate it up the call stack
        }
    }

    //public void Insert(MasterMenu entity)
    //    {
    //        using (SqlConnection conn = new SqlConnection(Helper.GetConnectionString()))
    //        {
    //            string storedProcedureName = "InsertMasterMenu";

    //            using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
    //            {
    //                cmd.CommandType = CommandType.StoredProcedure;

    //                // Add parameters
    //                cmd.Parameters.AddWithValue("@nama_menu", entity.nama_menu);
    //                cmd.Parameters.AddWithValue("@harga_menu", entity.harga_menu);
    //                cmd.Parameters.AddWithValue("@deskripsi_menu", entity.deskripsi_menu);

    //                // Open connection
    //                conn.Open();

    //                // Execute the command
    //                int rowsAffected = cmd.ExecuteNonQuery();

    //            }
    //        }
    //    }

public void Insert(MasterMenu entity)
    {
        using (SqlConnection conn = new SqlConnection(Helper.GetConnectionString()))
        {
            string storedProcedureName = "InsertMasterMenu";

            // Use Dapper's Execute method
            conn.Execute(storedProcedureName,
                new
                {
                    entity.nama_menu,
                    entity.harga_menu,
                    entity.deskripsi_menu
                },
                commandType: CommandType.StoredProcedure);
        }
    }



    public void Update(MasterMenu entity)
        {
            using (SqlConnection conn = new SqlConnection(Helper.GetConnectionString()))
            {
                string storedProcedureName = "sp_UpdateMenu";

                using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    cmd.Parameters.AddWithValue("@id_menu", entity.id_menu);
                    cmd.Parameters.AddWithValue("@nama_menu", entity.nama_menu);
                    cmd.Parameters.AddWithValue("@harga_menu", entity.harga_menu);
                    cmd.Parameters.AddWithValue("@deskripsi_menu", entity.deskripsi_menu);

                    // Open connection
                    conn.Open();

                    // Execute the command
                    int rowsAffected = cmd.ExecuteNonQuery();
                }
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

        //public MasterMenu GetById(int id)
        //{
        //   using (SqlConnection conn = new SqlConnection(GetConnectionString()))
        //    {
        //        string strSql = @"select * from MasterMenu where id_menu=@id_menu";
        //        var param = new { id_menu = id };
        //        var data = conn.QueryFirstOrDefault<MasterMenu>(strSql, param);
        //        return data;
        //    }
        //}

        public IEnumerable<MasterMenu> GetByName(string name)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"select * from MasterMenu where nama_menu like @nama_menu";
                var param = new { nama_menu = "%" + name + "%" };
                var data = conn.Query<MasterMenu>(strSql, param);
                return data;
            }   
      
        }


        public IEnumerable<MasterMenu> GetWithPaging(int pageNumber, int pageSize, string name)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"SELECT * FROM MasterMenu
                       WHERE nama_menu LIKE @NamaMenu 
                       ORDER BY nama_menu 
                       OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";
                var param = new { NamaMenu = $"%{name}%", Offset = (pageNumber - 1) * pageSize, PageSize = pageSize };
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

        public MasterMenu GetByID(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"select * from MasterMenu where id_menu=@id_menu";
                var param = new { id_menu = id };
                var data = conn.QueryFirstOrDefault<MasterMenu>(strSql, param);
                return data;
            }

        }
    }
}
