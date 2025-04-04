namespace ZenithCMS.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; } // Store bcrypt hashed password
        public string Role { get; set; } // For role-based authorization
    }
}
