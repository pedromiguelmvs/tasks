using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("users")]
public class User(string username, string password) {

  [Key]
  [Column("id")]
  public int Id { get; set; }

  [Column("username")]
  public string Username { get; set; } = username;

  [Column("password")]
  public string Password { get; set; } = password;

  [Column("created_at")]
  public DateTime CreatedAt { get; set; }

  [Column("updated_at")]
  public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

  [Column("deleted_at")]
  public DateTime? DeletedAt { get; set; }
}