using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using pos.DAL.Interface;
using pos.BO;
using Dapper;
using System.Data.SqlClient;
namespace pos.DAL.DAL


{
    public class UserDAL : IUserDAL
    {
        private string GetConnectionString()
        {
            return Helper.GetConnectionString();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<User> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                var strSql = @"select * from [User] order by Username";
                var results = conn.Query<User>(strSql);
                return results;
            }
        }
        public void Insert(User entity)
        {
            using(SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"insert into [User] (Username, Password) values (@Username, @Password)";
                var param = new {Username = entity.Username, Password = entity.Password};
                conn.Execute(strSql, param);
            }
        }
        public User Login(string name, string password)
        {
            using(SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"select * from [User] where Username=@Username and Password=@Password";
                var param = new {Username = name, Password = password};
                var result = conn.QuerySingleOrDefault<User>(strSql, param);
                if( result == null)
                {
                    throw new Exception("Invalid Username or Password");
                }
                var strSqlRole = @"select r.* from [UsersRoles] ur
                               inner join [Roles] r on ur.RoleID = r.RoleID
                               where ur.Username = @Username";
                var roles = conn.Query<Roles>(strSqlRole, param);
                result.Roles = roles;
                return result;
              

            }
        }

        public User GetByUsername(string username)
        {
            using(SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"select * from [User] where Username=@Username";
                var param = new {Username = username};
                var result = conn.QuerySingleOrDefault<User>(strSql, param);
                return result;
            }
        }
        public IEnumerable<User> GetAllWithRoles()
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"select * from [User]";
                var results = conn.Query<User>(strSql);
                foreach (var item in results)
                {
                    string strSqlRole = @"select r.* from [UsersRoles] ur
                               inner join [Roles] r on ur.RoleID = r.RoleID
                               where ur.Username = @Username";
                    var param = new { Username = item.Username };
                    var roles = conn.Query<Roles>(strSqlRole, param);
                    item.Roles = roles;
                }
                return results;
            }
            
        }
        public User GetUserWithRoles(string username)
        {
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                string strSql = @"select * from [User] where Username=@Username";
                var param = new { Username = username };
                var result = conn.QuerySingleOrDefault<User>(strSql, param);
                if (result != null)
                {


                    string strSqlRole = @"select r.* from [UsersRoles] ur
                               inner join [Roles] r on ur.RoleID = r.RoleID
                               where ur.Username = @Username";
                    var paramRole = new { Username = result.Username };
                    var roles = conn.Query<Roles>(strSqlRole, param);
                    result.Roles = roles;
                }

                return result;
            }
        }
        User ICrud<User>.GetByID(int id)
        {
            throw new NotImplementedException();
        }

        void ICrud<User>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        void ICrud<User>.Update(User entity)
        {
            throw new NotImplementedException();
        }


        void IUserDAL.ChangePassword(string username, string newPassword)
        {
            throw new NotImplementedException();
        }
    }
}
