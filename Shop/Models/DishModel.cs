namespace Shop.Models;

/// <summary>
/// Dish model for creating an order
/// </summary>
/// <param name="DishId">dish id</param>
/// <param name="Quantity">dish quantity</param>
public record DishModel(int DishId, int Quantity);