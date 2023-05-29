using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public class User
{
    [Key] public int Id { get; set; }

    [Required] [MaxLength(50)] public string Username { get; set; }

    [Required] [MaxLength(100)] public string Email { get; set; }

    [Required] [MaxLength(255)] public string PasswordHash { get; set; }

    [Required] [MaxLength(10)] public string Role { get; set; }

    [Required] public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [Required] public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}