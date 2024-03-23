using System;
using System.Collections.Generic;
using System.Text;
using pos.BLL.DTO;
using pos.BLL.Interface;
using pos.BO;
using pos.DAL.Interface;
using pos.DAL.DAL;
using pos.DALnew.DAL;


namespace pos.BLL
{
    public class UserBLL :IUserBLL
    {
        private readonly IUserDAL _userDAL;
        public UserBLL()
        {
            _userDAL = new UserDAL();

        }
        public void Insert(UserCreateDTO entity)
        {
            if (string.IsNullOrEmpty(entity.Username))
            {
                throw new Exception("Username is required");
            }
            if (string.IsNullOrEmpty(entity.Password))
            {
                throw new Exception("Password is required");
            }
            try
            {
                var newUser = new User
                {
                    Username = entity.Username,
                    Password = entity.Password
                };
                _userDAL.Insert(newUser);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public UserDTO Login(string name, string password)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Username is required");
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new Exception("Password is required");
            }
            try
            {
                var user = _userDAL.Login(name, password);
                if (user == null)
                {
                    throw new Exception("Invalid username or password");
                }
                var userDTO = new UserDTO
                {
                    Username = user.Username,
                    Password = user.Password
                };
                return userDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }   
        }

        public UserDTO LoginMVC(LoginDTO loginDTO)
        {
            if (string.IsNullOrEmpty(loginDTO.Username))
            {
                throw new ArgumentException("Username is required");
            }
            if (string.IsNullOrEmpty(loginDTO.Password))
            {
                throw new ArgumentException("Password is required");
            }
            try
            {
                var result = _userDAL.Login(loginDTO.Username,loginDTO.Password);
                if (result == null)
                {
                    throw new ArgumentException("Username or Password is wrong");
                }

                var lstRolesDto = new List<RoleDTO>();
                var roles = result.Roles;
                foreach (var role in roles)
                {
                    lstRolesDto.Add(new RoleDTO
                    {
                        RoleID = role.RoleID,
                        RoleName = role.RoleName
                    });
                }

                UserDTO userDTO = new UserDTO
                {
                    Username = result.Username,
                    Roles = lstRolesDto
                };

                return userDTO;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        //public IEnumerable<UserDTO> GetAllWithRoles()
        //{
        //    var users = _userDAL.GetAllWithRoles();
        //    var usersDTO = new List<UserDTO>();
        //    foreach (var user in users)
        //    {
        //        var userDto = new UserDTO
        //        {
        //            Username = user.Username
        //        };
        //        var lstRolesDto = new List<RoleDTO>();
        //        var roles = user.Roles;
        //        foreach (var role in roles)
        //        {
        //            lstRolesDto.Add(new RoleDTO
        //            {
        //                RoleID = role.RoleID,
        //                RoleName = role.RoleName
        //            });
        //        }
        //    }
        //    return usersDTO;
        //}

        public IEnumerable<UserDTO> GetAllWithRoles()
        {
            var users = _userDAL.GetAllWithRoles();
            var usersDTO = new List<UserDTO>();

            foreach (var user in users)
            {
                var lstRolesDto = new List<RoleDTO>();

                foreach (var role in user.Roles)
                {
                    lstRolesDto.Add(new RoleDTO
                    {
                        RoleID = role.RoleID,
                        RoleName = role.RoleName
                    });
                }

                usersDTO.Add(new UserDTO
                {
                    Username = user.Username,
                    Roles = lstRolesDto
                });
            }

            return usersDTO;
        }

        public UserDTO GetUserWithRoles(string username)
        {
            var user = _userDAL.GetUserWithRoles(username);

            if (user == null)
            {
                throw new ArgumentException("User not found");
            }
            var userDto = new UserDTO
            {
                Username = user.Username
            };
            var lstRolesDto = new List<RoleDTO>();
            var roles = user.Roles;
            foreach (var role in roles)
            {
                lstRolesDto.Add(new RoleDTO
                {
                    RoleID = role.RoleID,
                    RoleName = role.RoleName
                });
            }

            userDto.Roles = lstRolesDto;

            return userDto;
        }





        void IUserBLL.ChangePassword(string name, string newPassword)
        {
            throw new NotImplementedException();
        }

        void IUserBLL.Delete(string name)
        {
            throw new NotImplementedException();
        }

        IEnumerable<UserDTO> IUserBLL.GetAll()
        {
            var users = _userDAL.GetAll();
            var usersDTO = new List<UserDTO>();
            foreach (var user in users)
            {
                usersDTO.Add(new UserDTO
                {
                    Username = user.Username,

                });
            }
            return usersDTO;

        }
    }
    }

