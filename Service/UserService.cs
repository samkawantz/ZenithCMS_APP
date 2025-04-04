using System.Linq;
using BCrypt.Net;
using ZenithCMS.Data; // Corrected 'using' statement
using ZenithCMS.Models;

namespace ZenithCMS.Service
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public User Authenticate(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user != null && BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
            {
                return user;
            }
            return null;
        }

        public void Register(string username, string email, string password, string role = "User")
        {
            string hashedPassword = HashPassword(password);
            var user = new User
            {
                Username = username,
                Email = email,
                PasswordHash = hashedPassword,
                Role = role // Assign default role as "User"
            };

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);
        }
    }
}
