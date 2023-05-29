using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;

public class Order
{
    [Key] public int Id { get; set; }

    [Required] public int UserId { get; set; }

    [Required] [ForeignKey("UserId")] public User User { get; set; }

    [Required] [MaxLength(50)] public string Status { get; set; }

    public string? SpecialRequests { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}