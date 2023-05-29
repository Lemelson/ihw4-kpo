namespace Shop.Requests.Dish;

/// <summary>
/// Model for changing the dish
/// </summary>
/// <param name="Signature">jwt token signature</param>
/// <param name="DishId">dish id</param>
/// <param name="Name">dish name</param>
/// <param name="Description">dish description</param>
/// <param name="Price">dish price</param>
/// <param name="Quantity">dish quantity</param>
public record EditDishRequest(string Signature, int DishId, string Name, string? Description, decimal Price,
    int Quantity);