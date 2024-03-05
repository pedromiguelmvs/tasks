
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("tasks")]
public class AppTask {

  [Key]
  [Column("id")]
  public int Id { get; set; }

  [Column("name")]
  public string Name { get; set; } = "Nova tarefa";

  [Column("description")]
  public string Description { get; set; } = "Nova descrição";

  [Column("done")]
  public bool Done { get; set; }

  [Column("created_at")]
  public DateTime CreatedAt { get; set; }

  [Column("updated_at")]
  public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

  [Column("deleted_at")]
  public DateTime? DeletedAt { get; set; }

  [Column("user_id")]
  public int UserId { get; set; }

  public User User { get; set; }
}