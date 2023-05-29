namespace Shop.Requests.Dish;

/// <summary>
/// Model for removing a dish
/// </summary>
/// <param name="Signature">jwt token signature</param>
/// <param name="DishId">id</param>
public record DeleteDishRequest(string Signature, int DishId);