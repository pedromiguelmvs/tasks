namespace Api.Modules.Users
{
    public class UpdateUserDto(string username, string password)
    {
        public int Id { get; set; }

        public string Username { get; set; } = username;

        public string Password { get; set; } = password;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? DeletedAt { get; set; }
    }
}