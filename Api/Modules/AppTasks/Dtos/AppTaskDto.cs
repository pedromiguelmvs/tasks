using System.ComponentModel.DataAnnotations;

public class AppTaskDto(string name, string description)
  {
    public int Id { get; set; }
    [Required]
    [MinLength(3)]
    public string Name { get; set; } = name;
    public string Description { get; set; } = description;
  }