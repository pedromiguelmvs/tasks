using System.ComponentModel.DataAnnotations;

namespace Api.Modules.Auth
{
  public class AuthDto(string username, string password)
  {
    [Required(ErrorMessage = "O campo 'nome de usuário' é obrigatório!")]
    public string Username { get; set; } = username;

    [Required(ErrorMessage = "O campo 'senha' é obrigatório!")]
    public string Password { get; set; } = password;
  }
}