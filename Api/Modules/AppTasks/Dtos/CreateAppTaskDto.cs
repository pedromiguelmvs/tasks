using System.ComponentModel.DataAnnotations;

namespace Api.Modules.AppTasks
{
  public class CreateAppTaskDto(string name, string description, int userId)
  {
    [Required(ErrorMessage = "O nome é obrigatório!")]
    [MinLength(3)]
    public string Name { get; set; } = name;

    [MinLength(3)]
    public string Description { get; set; } = description;

    [Required(ErrorMessage = "É obrigatório informar o usuário ao criar uma tarefa!")]
    public int UserId { get; set; } = userId;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }
  }
}