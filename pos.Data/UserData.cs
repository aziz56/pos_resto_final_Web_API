using Microsoft.EntityFrameworkCore;
using posServices.Data.Interfaces;
using posServices.Domain.Models;

namespace posServices.Data
{
    public class UserData : IUser
    {
        private readonly AppDbContext _context;
        public UserData(AppDbContext context)
        {
            _context = context;
        }

        public Task<Task> ChangePassword(string username, string newPassword)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var users = await _context.Users.ToListAsync();
            return users;


        }

        public async Task<IEnumerable<User>> GetAllWithRoles()
        {
            var users = await _context.Users.Include(u => u.Roles).ToListAsync();
            return users;
        }

        public async Task<User> GetByUsername(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }
            return user;

        }

        public Task<User> GetUserWithRoles(string username)
        {
            var user = _context.Users.Include(u => u.Roles).FirstOrDefault(u => u.Username == username);
            return Task.FromResult(user);

        }

        public async Task<User> Insert(User entity)
        {
            try
            {
                var user = new User
                {
                    Username = entity.Username,
                    Password = Helpers.Md5Hash.GetHash(entity.Password),
                    Roles = entity.Roles
                };  
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return user;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username && u.Password == Helpers.Md5Hash.GetHash(password));
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }
            return user;
        }
        public async Task<User> Update(User entity)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == entity.Username);
            if (user == null)
            {
                throw new ArgumentException("User not found");
            }
            user.Username = entity.Username;
            user.Password = entity.Password;
            user.Roles = entity.Roles;
            await _context.SaveChangesAsync();
            return user;
        }
    }
}



