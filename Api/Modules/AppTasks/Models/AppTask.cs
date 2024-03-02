
using System.ComponentModel.DataAnnotations.Schema;

[Table("tasks")]
public class AppTask {
  [Column("id")]
  public int Id { get; set; }

  [Column("name")]
  public string Name { get; set; } = "Nova tarefa";

  [Column("description")]
  public string Description { get; set; } = "Nova descrição";
}