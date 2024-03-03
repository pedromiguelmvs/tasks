using System.ComponentModel.DataAnnotations;

public class UserDto(string username, string password) {
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O campo 'nome de usuário' é obrigatório!")]
    public string Username { get; set; } = username;
    
    [Required(ErrorMessage = "O campo 'senha' é obrigatório!")]
    public string Password { get; set; } = password;

    public DateTime CreatedAt { get; set; }
    
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
    public DateTime? DeletedAt { get; set; }
}