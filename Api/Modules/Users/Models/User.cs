using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("users")]
public class User {

  [Key]
  [Column("id")]
  public int Id { get; set; }

  [Column("username")]
  public string Username { get; set; }

  [Column("password")]
  public string Password { get; set; }

  [Column("created_at")]
  public DateTime CreatedAt { get; set; }

  [Column("updated_at")]
  public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

  [Column("deleted_at")]
  public DateTime? DeletedAt { get; set; }

  public ICollection<AppTask> AppTasks { get; set; }
}