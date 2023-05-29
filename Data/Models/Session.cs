using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;

public class Session
{
    [Key] public int Id { get; set; }

    [Required] public int UserId { get; set; }

    [ForeignKey("UserId")] public User User { get; set; }

    [Required] [MaxLength(255)] public string SessionToken { get; set; }

    [Required] public DateTime ExpiresAt { get; set; }
}