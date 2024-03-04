using System.ComponentModel.DataAnnotations;

public class AppTaskDto(string name, string description, int userId)
  {
    public int Id { get; set; }
    
    [Required(ErrorMessage = "O nome é obrigatório!")]
    [MinLength(3)]
    public string Name { get; set; } = name;
    
    [MinLength(3)]
    public string Description { get; set; } = description;
    
    [Required(ErrorMessage = "É obrigatório informar o usuário ao criar uma tarefa!")]
    public int UserId { get; set; } = userId;
  }