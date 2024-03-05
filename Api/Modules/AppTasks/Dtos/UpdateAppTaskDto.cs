using System.ComponentModel.DataAnnotations;

namespace Api.Modules.AppTasks
{
  public class UpdateAppTaskDto(int id, string name, string description, bool done)
  {
    [Required(ErrorMessage = "O ID é obrigatório!")]
    public int Id { get; set; } = id;
    
    [Required(ErrorMessage = "O nome é obrigatório!")]
    [MinLength(3)]
    public string Name { get; set; } = name;

    [MinLength(3)]
    public string Description { get; set; } = description;

    [Required(ErrorMessage = "O status é obrigatório!")]
    public bool Done { get; set; } = done;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }
  }
}