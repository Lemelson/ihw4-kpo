using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;

public class OrderDish
{
    [Key] public int Id { get; set; }

    [Required] public int OrderId { get; set; }

    [Required] [ForeignKey("OrderId")] public Order Order { get; set; }

    [Required] public int DishId { get; set; }

    [Required] [ForeignKey("DishId")] public Dish Dish { get; set; }

    [Required] public decimal Price { get; set; }

    [Required] public int Quantity { get; set; }
}